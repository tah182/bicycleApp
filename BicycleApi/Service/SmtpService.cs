using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BicycleApi.Business;
using BicycleApi.Configuration;

namespace BicycleApi.Service {
    public class SmtpService : IEmailService {
        private readonly EmailAddress defaultEmailFrom;
        private readonly string smtpUsername, smtpPassword, smtpHost;
        private readonly int smtpPort;
        
        public SmtpService (IOptions<SmtpSettings> options) : this(options.Value.DefaultEmailFrom, options.Value.Username, options.Value.Password, options.Value.SmtpHost, options.Value.SmtpPort) { }

        public SmtpService (EmailAddress defaultEmailFrom, string smtpUsename, string smtpPassword, string smtpHost, int smtpPort) {
            this.defaultEmailFrom = defaultEmailFrom;
            this.smtpUsername = smtpUsename;
            this.smtpPassword = smtpPassword;
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
        }

        public void SendEmail(EmailMessage emailMessage) {
            SendEmailAsync(emailMessage)
                .GetAwaiter()
                .GetResult();
        }

        public async Task SendEmailAsync(EmailMessage emailMessage) {
            var mailMessage = new MailMessage {
                From = new MailAddress(emailMessage.EmailFrom?.Address ?? defaultEmailFrom.Address, defaultEmailFrom.SimpleName),
                Subject = emailMessage.Subject,
                Body = emailMessage.Body
            };
            mailMessage.To.Add(emailMessage.EmailTo);

            var smtpClient = new SmtpClient {
                Credentials = new NetworkCredential(this.smtpUsername, this.smtpPassword),
                Host = this.smtpHost,
                Port = this.smtpPort
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}