using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers;
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
        
        public void SendEmail(string emailTo, string body, string subject, string emailFrom = null, bool? isHtml = false) {
            SendEmailAsync(emailTo, body, subject, emailFrom, isHtml)
                .GetAwaiter()
                .GetResult();
        }

        public async Task SendEmailAsync(string emailTo, string body, string subject, string emailFrom = null, bool? isHtml = false) {
            var client = new SendGridClient(apiKey);
            var from = new SendGrid.Helpers.Mail.EmailAddress(emailFrom ?? defaultEmailFrom.Address, defaultEmailFrom.SimpleName);
            var to = new SendGrid.Helpers.Mail.EmailAddress(emailTo);
            var plainTextContent = Regex.Replace(body, "<[^>]*>", "");
            var msg = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, body);
            var response = await client.SendEmailAsync(msg);
            
        }
    }
}