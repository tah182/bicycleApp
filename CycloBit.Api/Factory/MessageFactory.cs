using CycloBit.Api.Configuration;
using CycloBit.Api.Business;

namespace CycloBit.Api.Factory {
    public static class MessageFactory {
        public static EmailMessage CreateEmailMessage(string emailTo, string subject, string body, string emailFrom = null, string emailFromName = null, bool isHtml = true) {
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