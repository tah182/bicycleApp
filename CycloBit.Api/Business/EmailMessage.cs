using System.ComponentModel.DataAnnotations;
using CycloBit.Api.Configuration;

namespace CycloBit.Api.Business {
    public class EmailMessage {
        private bool isHtml = false;

        [Required]
        [EmailAddress]
        public string EmailTo { get; set; }
        public EmailAddress EmailFrom { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public bool IsHtml {
            get { return isHtml; }
            set { this.isHtml = value; }
        }
    }
}