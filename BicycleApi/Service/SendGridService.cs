using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers;
using BicycleApi.Business;
using BicycleApi.Configuration;

namespace BicycleApi.Service
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
            
            switch (response.StatusCode) {
                case 400:
                    throw new Exception("Bad Request");
                case 401:
                    throw new Exception("Requires Authentication");
                case 406:
                    throw new Exception("Missing Accept header. example: Accept: application/json");
                case 429:
                    throw new Exception("Too Many Requests");
                case 500:
                    throw new Exception("Internal Service Error");
                case 201:   // successfully created
                case 204:   // successfully deleted
                    break;
            }
        }
    }
}