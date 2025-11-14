using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BusinessAccessLayes.Services.Classes
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
            {
                Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword),
                EnableSsl = true
            };

            var message = new MailMessage(_emailSettings.SenderEmail, to, subject, body)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(message);
        }

    }
}
