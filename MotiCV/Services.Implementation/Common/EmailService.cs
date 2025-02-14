﻿using Domain.Configurations;
using Microsoft.Extensions.Options;
using Services.Common;
using System.Net.Mail;
using System.Net;

namespace Services.Implementation.Common
{
    public class EmailService : SmtpClient, IEmailService
    {
        private readonly EmailConfiguration options;

        public EmailService(IOptions<EmailConfiguration> options)
        {
            this.options = options.Value;

            Host = this.options.Host;
            Port = this.options.Port;
            EnableSsl = this.options.EnableSsl;
            Credentials = new NetworkCredential(this.options.UserName, this.options.Password);
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            using (var message = new MailMessage())
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.From = new MailAddress(options.UserName, options.DisplayName);

                message.To.Add(to);

                await SendMailAsync(message);
            }
        }
    }
}
