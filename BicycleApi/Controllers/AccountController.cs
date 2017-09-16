using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BicycleApi.Binding;
using BicycleApi.Logging;
using BicycleApi.Model;

namespace BicycleApi.Controllers {
    [Route("[controller]")]
    public class AccountController : BaseUserController<AccountController> {
        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger) : base(userManager, signInManager, logger) { }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterUserBindingModel model) {
            
            if (model.Password != model.PasswordConf)
                return BadRequest("Passwords must match.");

            var user = (ApplicationUser)model;
            var result = this.UserManager.CreateAsync(user, model.Password);

            if (result.Result.Succeeded) {
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                var userResult = await this.SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
                return Ok(userResult);
            }

            this.Logger.LogError(LoggingEvents.CreateUser, "Unable to create user: {userName}, email: {email}", model.UserName, model.Email);
            return BadRequest("Unable to create account, please try again.");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginUserBindingModel model) {
            var loginResult = await this.SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
            
            if (loginResult.Succeeded) {
                this.Logger.LogInformation(LoggingEvents.Login, "User logged in: {username}", model.UserName);
                return Ok();
            }
            
            // if (loginResult.RequiresTwoFactor) {
            //     return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            // }

            if (loginResult.IsLockedOut) {
                this.Logger.LogWarning(LoggingEvents.AccountLockout, "User {username} account locked out.", model.UserName);
                return Ok("Lockedout");
            } 
            
            return Unauthorized();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await this.SignInManager.SignOutAsync();
            this.Logger.LogInformation(LoggingEvents.Logout, "User logged out.");
            
            return Ok();
        }
    }
}