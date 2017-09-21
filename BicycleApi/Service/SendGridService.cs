using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BicycleApi.Service {
    public class SendGridService : IMessageService {
        private readonly string smtpHost, smtpUsername, smtpPassword;
        private readonly int smtpPort;

        public SendGridService(IOptions<ConfigOptions> options) : this(options.Value.SmtpSettings.Username, 
                                                                       options.Value.SmtpSettings.Password, 
                                                                       options.Value.SmtpSettings.SmtpHost,
                                                                       options.Value.SmtpSettings.SmtpPort) { }

        public SendGridService(string smtpUsername, string smtpPassword, string smtpHost, int smtpPort) {
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
        }
        
        public void SendMessage(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false) {
            SendMessageAsync(emailFrom, emailTo, body, subject, isHtml)
                .GetAwaiter()
                .GetResult();
        }

        public async Task SendMessageAsync(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false) {

            var mailMessage = new MailMessage {
                From = new MailAddress(emailFrom),
                Subject = subject,
                Body = body,
            };
            mailMessage.To.Add(emailTo);

            var smtpClient = new SmtpClient {
                Credentials = new NetworkCredential(this.smtpUsername, this.smtpPassword),
                Host = this.smtpHost,
                Port = this.smtpPort
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}