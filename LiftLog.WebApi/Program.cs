using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LiftLog.WebApi.Utils.Services.Auth;
using LiftLog.WebApi.Utils.Models.Identity;
using LiftLog.WebApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using LiftLog.WebApi.Utils.Models.Emailing;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

#region Auth
var jwtConf = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConf.Issuer,
        ValidAudience = jwtConf.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf.SecretKey))
    };
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
builder.Services.AddTransient<LiftLog.WebApi.Utils.Models.Emailing.IEmailSender, EmailSender>();

#endregion

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiftLogAPI", Version = "v1" });
});

var app = builder.Build();

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
