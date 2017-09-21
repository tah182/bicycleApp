namespace BicycleApi {
    public class ConfigOptions {
        public ConfigOptions() { }

        public SmtpSettings SmtpSettings { get; set; }
    }

    public class SmtpSettings {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
    }
}