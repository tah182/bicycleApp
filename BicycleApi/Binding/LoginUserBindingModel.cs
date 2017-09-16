using System.ComponentModel.DataAnnotations;

namespace BicycleApi.Binding {
    public class LoginUserBindingModel {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}