using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BicycleApi.Model;

namespace BicycleApi.Controllers {

    [Authorize]
    public abstract class BaseUserController<T> : BaseController<T> {
        
        protected readonly UserManager<ApplicationUser> UserManager;
        protected readonly SignInManager<ApplicationUser> SignInManager;

        public BaseUserController (UserManager<ApplicationUser> userManager, 
                                   SignInManager<ApplicationUser> signInManager, 
                                   ILogger<T> logger, 
                                   BicycleContext db) : base(logger, db) {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

    }
}