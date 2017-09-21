using System;
using System.Threading.Tasks;

namespace BicycleApi.Service {
    public interface IMessageService
    {
         void SendMessage(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false);
         Task SendMessageAsync(string emailFrom, string emailTo, string body, string subject, bool? isHtml = false);

    }
}