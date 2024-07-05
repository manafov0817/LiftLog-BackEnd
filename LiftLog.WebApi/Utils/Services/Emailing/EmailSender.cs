using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using LiftLog.WebApi.Utils.Models.Emailing;
using LiftLog.WebApi.Utils.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace LiftLog.WebApi.Utils.Services.Emailing
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(MailRequest mailrequest);
        Task<bool> SendConfirmationEmailAsync(HttpRequest req, User user);
    }

    public class EmailSender : IEmailSender
    {
        private readonly IWebHostEnvironment? _hostEnvironment;
        private readonly EmailSettings _emailSettings;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<EmailSender> _authLogger;

        public EmailSender(IOptions<EmailSettings> emailSettings,
                           IWebHostEnvironment hostEnvironment,
                           UserManager<User> userManager,
                           ILogger<EmailSender> logger)
        {
            _emailSettings = emailSettings.Value;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _authLogger = logger;
        }

        public async Task<bool> SendEmailAsync(MailRequest mailrequest)
        {
            try
            {
                _authLogger.LogInformation($"Sending Email to: {mailrequest.ToEmail}");
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_emailSettings.From);
                email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
                email.Subject = mailrequest.Subject;
                var builder = new BodyBuilder();

                builder.HtmlBody = mailrequest.Body;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.From, _emailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                _authLogger.LogInformation($"Email sent successfully to: {mailrequest.ToEmail}");
                return true;
            }
            catch (Exception ex)
            {
                _authLogger.LogError(ex.InnerException?.Message);
                return false;
            }
        }

        public async Task<bool> SendConfirmationEmailAsync(HttpRequest req, User user)
        {
            string confirmMailBody = await CreateConfirmEmailBody(req, user);

            return await SendEmailAsync(new(user.Email, "Please Confirm Your Email", confirmMailBody));
        }

        public async Task<string> CreateConfirmEmailBody(HttpRequest req, User user)
        {
            try
            {
                string confirmUrl = await CreateConfirmUrlAsync(req, user);

                string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "Scripts", "confirmation_email_template.html");
                string emailContent = await System.IO.File.ReadAllTextAsync(filePath);
                emailContent = emailContent.Replace("YOUR_CONFIRMATION_LINK_HERE", confirmUrl);

                return emailContent;
            }
            catch (Exception ex)
            {
                _authLogger.LogError(ex.InnerException.Message);
                return "#";
            }
        }

        public async Task<string> CreateConfirmUrlAsync(HttpRequest req, User user)
        {
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string codeHtmlVersion = HttpUtility.UrlEncode(code);
            return $"{req.Scheme}://{req.Host.Value}/api/Auth/confirmEmail?userId={user.Id}&code={codeHtmlVersion}";
        }

    }

}
