using System.Threading.Tasks;
using CycloBit.Api.Model;

namespace CycloBit.Api.Service
{
    public interface IEmailService
    {
         void SendEmail(EmailMessage emailMessage);
         Task SendEmailAsync(EmailMessage mailMesemailMessagesage);

    }
}