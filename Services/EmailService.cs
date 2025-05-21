using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ProfileCardApp.Models;

namespace ProfileCardApp.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendContactMessageAsync(ContactMessage message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            email.To.Add(new MailboxAddress("Receiver", _settings.ReceiverEmail));
            email.Subject = $"New Contact Form Submission from {message.Name}";

            email.Body = new TextPart("plain")
            {
                Text = $"Name: {message.Name}\nEmail: {message.Email}\nMessage:\n{message.Message}"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.SmtpServer, _settings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
