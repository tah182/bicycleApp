using System.ComponentModel.DataAnnotations;
using CycloBit.Api.Model;

namespace CycloBit.Api.Binding {
    public class RegisterUserBindingModel : ApplicationUser {
        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConf { get; set; }
    }
}