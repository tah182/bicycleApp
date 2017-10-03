using System.ComponentModel.DataAnnotations;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Binding {
    public class RegisterUserBindingModel : ApplicationUser {
        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConf { get; set; }
    }
}