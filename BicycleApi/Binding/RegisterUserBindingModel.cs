using System.ComponentModel.DataAnnotations;
using BicycleApi.Model;

namespace BicycleApi.Binding {
    public class RegisterUserBindingModel : ApplicationUser {
        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConf { get; set; }
    }
}