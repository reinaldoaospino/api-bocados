using System;
using Domain.Entities;
using System.Threading.Tasks;
using Domain.Interfaces.Application;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;

namespace Application.Managers
{
    public class EmailManager : IEmailManager
    {
        private readonly string _bocadosEmail;
        public EmailManager(IConfiguration configuration)
        {
            _bocadosEmail = configuration["AppSettings:bocadosEmail"];
        }
        public void SendEmail(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(email.Name, email.EmailAddres));
            message.To.Add(new MailboxAddress("Bocados", _bocadosEmail));
            message.Subject = email.Subject;

            message.Body = new TextPart("plain")
            {
                Text = email.Message
            };

            using var client = new SmtpClient
            {
                CheckCertificateRevocation = false
            };

            client.Connect("smtp.gmail.com", 587);


            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            client.AuthenticationMechanisms.Remove("XOAUTH2");

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate("gestor.correos.bocados@gmail.com", "Chawla-22");

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
