using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BicycleApi.Service {
    public class SendGridService : IMessageService {
        private string smtpHost => "smtp.sendgrid.net";
        private string _smtpUsername, _smtpPassword;
        private int? _smtpPort;
        private string smtpUsername { 
            get { return this._smtpUsername ?? "defaultUsername"; }
            set { this._smtpUsername = value; }
        }
        private string smtpPassword {
            get { return this._smtpPassword ?? "defaultPassword"; }
            set { this._smtpPassword = value; }
        }
        private int smtpPort {
            get { return this._smtpPort ?? 587; }
        }

        public SendGridService(string smtpUsername = null, string smtpPassword = null, int? smtpPort = null) {
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
            this._smtpPort = smtpPort;
        }
        
        public void SendMessage(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false) {
            SendMessageAsync(emailFrom, emailTo, body, subject, isHtml).GetAwaiter().GetResult();
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

            smtpClient.SendAsync(mailMessage, null);
        }
    }
}