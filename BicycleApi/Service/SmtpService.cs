using System.Threading.Tasks;

namespace BicycleApi.Service {
    public class SmtpService : IMessageService {
        
        public void SendMessage(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false) {
        }

        public async Task SendMessageAsync(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false) {
        }
    }
}