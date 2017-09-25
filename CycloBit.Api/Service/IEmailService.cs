using System;
using System.Threading.Tasks;
using CycloBit.Api.Business;

namespace CycloBit.Api.Service {
    public interface IEmailService
    {
         void SendEmail(EmailMessage emailMessage);
         Task SendEmailAsync(EmailMessage mailMesemailMessagesage);

    }
}