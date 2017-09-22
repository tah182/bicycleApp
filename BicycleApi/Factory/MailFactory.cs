using BicycleApi.Configuration;
using BicycleApi.Business;

namespace BicycleApi.Factory {
    public static class MailFactory {
        public static EmailMessage CreateEmailMessage(string emailTo, string body, string subject, string emailFrom = null, string emailFromName = null, bool isHtml = false) {
            EmailAddress fromEmailAddress = null;
            if (!string.IsNullOrWhiteSpace(emailFrom) && !string.IsNullOrWhiteSpace(emailFromName))
                fromEmailAddress = new EmailAddress { Address = emailFrom, SimpleName = emailFromName };

            return new EmailMessage {
                EmailFrom = fromEmailAddress,
                EmailTo = emailTo,
                Subject = subject,
                Body = body,
                IsHtml = isHtml
            };
        }
    }
}