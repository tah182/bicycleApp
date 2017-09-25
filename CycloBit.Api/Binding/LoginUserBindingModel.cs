using System.ComponentModel.DataAnnotations;

namespace CycloBit.Api.Binding {
    public class LoginUserBindingModel {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}