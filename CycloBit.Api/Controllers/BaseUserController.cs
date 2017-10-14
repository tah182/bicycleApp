using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Controllers
{

    [Authorize]
    public abstract class BaseUserController<T> : BaseController<T> {
        
        protected UserManager<ApplicationUser> UserManager { get; private set;}
        protected SignInManager<ApplicationUser> SignInManager { get; private set; }

        public BaseUserController (UserManager<ApplicationUser> userManager, 
                                   SignInManager<ApplicationUser> signInManager, 
                                   ILogger<T> logger, 
                                   CycloBitContext db) : base(logger, db) {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        protected override void Dispose(bool disposing) {
            if (!disposing) return;

            if (this.UserManager != null) {
                this.UserManager.Dispose();
                this.UserManager = null;
            }

            base.Dispose(disposing);
        }
    }
}