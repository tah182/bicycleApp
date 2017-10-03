using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers;
using CycloBit.Api.Model;
using CycloBit.Api.Configuration;

namespace CycloBit.Api.Service
{
    public class SendGridService : IEmailService {
        private readonly EmailAddress defaultEmailFrom;
        private readonly string apiKey;

        public SendGridService(IOptions<SmtpSettings> options) : this(options.Value.ApiKey, options.Value.DefaultEmailFrom) { }

        public SendGridService(string apiKey, EmailAddress defaultEmailFrom) {
            this.apiKey = apiKey;
            this.defaultEmailFrom = defaultEmailFrom;
        }
        
        public void SendEmail(EmailMessage emailMessage) {
            SendEmailAsync(emailMessage)
                .GetAwaiter()
                .GetResult();
        }

        public async Task SendEmailAsync(EmailMessage emailMessage) {
            var client = new SendGridClient(apiKey);
            var from = new SendGrid.Helpers.Mail.EmailAddress(emailMessage.EmailFrom?.Address ?? defaultEmailFrom.Address, defaultEmailFrom.SimpleName);
            var to = new SendGrid.Helpers.Mail.EmailAddress(emailMessage.EmailTo);
            var plainTextContent = Regex.Replace(emailMessage.Body, "<[^>]*>", "");
            var msg = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, emailMessage.Subject, plainTextContent, emailMessage.Body);
            var response = await client.SendEmailAsync(msg);
            
            if (response.StatusCode != HttpStatusCode.OK || response.StatusCode != HttpStatusCode.Created || response.StatusCode != HttpStatusCode.NoContent)
                throw new HttpListenerException((int)response.StatusCode);
        }
    }
}