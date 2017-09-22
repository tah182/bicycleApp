using System;
using System.Threading.Tasks;
using BicycleApi.Business;

namespace BicycleApi.Service {
    public interface IEmailService
    {
         void SendEmail(EmailMessage emailMessage);
         Task SendEmailAsync(EmailMessage mailMesemailMessagesage);

    }
}