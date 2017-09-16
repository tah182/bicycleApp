using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BicycleApi.Binding;
using BicycleApi.Model;

namespace BicycleApi.Controllers {
    [Route("[controller]")]
    public class AccountController : BaseUserController {
        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(userManager, signInManager) { }

        [HttpPost]
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
                await this.SignInManager.SignInAsync(user, isPersistent: false);
            }

            return Ok(result);
        }
    }
}