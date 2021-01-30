using API.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace API.Services
{
    public class EmailService : IEmailService
    {         
        private readonly string smtpUser = "gosu.bis@gmail.com";
        private readonly string smtpPass = "qyyuvzlfaqwkhlwt";

        public void Send(string subject, string message)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("gosu.bis@gmail.com"));
            email.To.Add(MailboxAddress.Parse("gosu.bis@gmail.com"));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(smtpUser, smtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}