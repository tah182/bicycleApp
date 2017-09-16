using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BicycleApi.Model;

namespace BicycleApi.Controllers {

    public abstract class BaseUserController : BaseController {
        
        protected readonly UserManager<ApplicationUser> UserManager;
        protected readonly SignInManager<ApplicationUser> SignInManager;

        public BaseUserController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

    }
}