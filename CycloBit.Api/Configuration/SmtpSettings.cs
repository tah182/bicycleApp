namespace CycloBit.Api.Configuration {
    public class SmtpSettings {
        public string ApiKey { get; set; }
        public EmailAddress DefaultEmailFrom { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
    }

    public class EmailAddress {
        public string Address { get; set; }
        public string SimpleName { get; set; }
    }
}