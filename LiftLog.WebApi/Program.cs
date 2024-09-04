using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete;
using LiftLog.Data.Abstract;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Data.Concrete.EfCore;
using LiftLog.Data.Concrete.EfCore.Utils;
using LiftLog.WebApi.DbContexts;
using LiftLog.WebApi.Utils.Models.Emailing;
using LiftLog.WebApi.Utils.Models.Identity;
using LiftLog.WebApi.Utils.Services.Auth;
using LiftLog.WebApi.Utils.Services.Emailing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
#region Auth
var jwtConf = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = jwtConf.Issuer,
            ValidAudience = jwtConf.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf.SecretKey))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("UserRole", "Admin"));
});

builder.Services.AddDbContext<IdentityContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

builder.Services.AddScoped(jts => new JwtTokenService(jwtConf.SecretKey, jwtConf.Issuer,
                                                      jwtConf.Audience, jwtConf.ExpiryInMinutes));
builder.Services.AddScoped<AuthenticationService>();
#endregion

#region Emailing
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailSender, EmailSender>();

#endregion

#region Repository Pattern Injections
// Data
builder.Services.AddScoped(typeof(IByUserProfileRepository<>), typeof(EfCoreByUserProfileRepository<>));
builder.Services.AddScoped<IUserProfileRepository, EfCoreProfileRepository>();
builder.Services.AddScoped<IExerciseRepository, EfCoreExerciseRepository>();
builder.Services.AddScoped<IMovementRepository, EfCoreMovementRepository>();
builder.Services.AddScoped<IWorkoutSessionRepository, EfCoreWorkoutSessionRepository>();
builder.Services.AddScoped<IWorkoutSessionLogRepository, EfCoreWorkoutSessionLogRepository>();


// Bussiness 

builder.Services.AddScoped<IUserProfileService, UserProfileManager>();
builder.Services.AddScoped<IExerciseService, ExerciseManager>();
builder.Services.AddScoped<IMovementService, MovementManager>();
builder.Services.AddScoped<IWorkoutSessionService, WorkoutSessionManager>();
builder.Services.AddScoped<IWorkoutSessionLogService, WorkoutSessionLogManager>();

#endregion

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiftLogAPI", Version = "v1" });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins); 

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiftLogAPI");
    c.RoutePrefix = string.Empty;
});

app.Run();
