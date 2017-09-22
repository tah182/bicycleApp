using System;
using System.Threading.Tasks;

namespace BicycleApi.Service {
    public interface IEmailService
    {
         void SendEmail(string emailTo, string body, string subject, string emailFrom = null, bool? isHtml = false);
         Task SendEmailAsync(string emailTo, string body, string subject, string emailFrom = null, bool? isHtml = false);

    }
}