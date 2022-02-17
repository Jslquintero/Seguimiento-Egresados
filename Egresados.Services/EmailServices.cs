using Egresados.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace Egresados.Services
{
    public class EmailServices : IEmailServices
    {
        // Our private configuration variables
        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _userName;
        private string _password;
        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // Use our configuration to send the email by using SmtpClient
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (Convert.ToBoolean(_configuration["EmailSender:UsarEmailSender"]))
            {
                _host = _configuration["EmailSender:Host"];
                _port = Convert.ToInt32(_configuration["EmailSender:Port"]);
                _enableSSL = Convert.ToBoolean(_configuration["EmailSender:EnableSSL"]);
                _userName = _configuration["EmailSender:UserName"];
                _password = _configuration["EmailSender:Password"];

                var client = new SmtpClient(_host, _port)
                {
                    //Credentials = new NetworkCredential(),
                    UseDefaultCredentials=false                  
                    //EnableSsl = _enableSSL
                };
                await client.SendMailAsync(new MailMessage(_userName, email, subject, htmlMessage) { IsBodyHtml = true });
            }

        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage, List<Attachment> attachments)
        {
            if (Convert.ToBoolean(_configuration["EmailSender:UsarEmailSender"]))
            {
                _host = _configuration["EmailSender:Host"];
                _port = Convert.ToInt32(_configuration["EmailSender:Port"]);
                _enableSSL = Convert.ToBoolean(_configuration["EmailSender:EnableSSL"]);
                _userName = _configuration["EmailSender:UserName"];
                _password = _configuration["EmailSender:Password"];

                var client = new SmtpClient(_host, _port)
                {
                    Credentials = new NetworkCredential(_userName, _password),
                    UseDefaultCredentials = false,
                    EnableSsl = _enableSSL
                };

                var mail = new MailMessage(_userName, email, subject, htmlMessage);
                mail.IsBodyHtml = true;
                foreach (var item in attachments)
                {
                    mail.Attachments.Add(item);
                }
                await client.SendMailAsync(mail);

            }

        }
    }
}
