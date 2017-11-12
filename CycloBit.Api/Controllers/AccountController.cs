using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using CycloBit.Api.Binding;
using CycloBit.Api.Configuration;
using CycloBit.Api.Factory;
using CycloBit.Api.Logging;
using CycloBit.Api.Service;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Controllers {
    [Route("[controller]")]
    public class AccountController : BaseUserController<AccountController> {
        private readonly IEmailService EmailService;
        private readonly IConfiguration Config;

        public AccountController(UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager,
                                  ILogger<AccountController> logger,
                                  CycloBitContext db,
                                  IEmailService emailService,
                                  IConfiguration config) : base(userManager, signInManager, logger, db) {
            this.EmailService = emailService;
            this.Config = config;
        }
        #region Anonymous

        [Route("register"), HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserBindingModel model) {
            if (model.Password != model.PasswordConf)
                return BadRequest("Passwords must match.");

            var user = (ApplicationUser)model;
            var result = this.UserManager.CreateAsync(user, model.Password);

            if (result.Result.Succeeded) {
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var emailMessage = MessageFactory.CreateEmailMessage(model.Email, "Confirm your account", "Please confirm your account by clicking this link: <a href=>link</a>");
                await EmailService.SendEmailAsync(emailMessage);
                var userResult = await this.SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);

                this.Logger.LogInformation(LoggingEvents.CreateUser, $"New user created: {model.UserName}, email: {model.Email}.");
                return Ok(userResult);
            }

            this.Logger.LogError(LoggingEvents.CreateUser, $"Unable to create user: {model.UserName}, email: {model.Email}.");
            return BadRequest("Unable to create account, please try again.");
        }

        [Route("test"), HttpPost]
        [AllowAnonymous]
        public IActionResult Test([FromBody] string value) {
            return Ok(value);
        }

        [Route("login"), HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserBindingModel model) {
            var loginResult = await this.SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
            
            if (loginResult.Succeeded) {
                this.Logger.LogInformation(LoggingEvents.Login, $"User logged in: {model.UserName}.");

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
        
                var key = JwtSecurityKey.Create(Config["Auth:Tokens:Key"]);
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
                var token = new JwtSecurityToken(Config["Auth:Tokens:Issuer"],
                                                 Config["Auth:Tokens:Issuer"],
                                                 claims,
                                                 expires: DateTime.Now.AddMinutes(30),
                                                 signingCredentials: creds);
        
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            
            // if (loginResult.RequiresTwoFactor) {
            //     return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            // }

            if (loginResult.IsLockedOut) {
                this.Logger.LogWarning(LoggingEvents.AccountLockout, "User {model.UserName} account locked out.");
                return Ok("Lockedout");
            } 
            
            return Unauthorized();
        }

        [Route("forgotpassword"), HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> ForgotPassword() {
            throw new NotImplementedException();    // change method to async
        }

        #endregion

        [Route("logout"), HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await this.SignInManager.SignOutAsync();
            this.Logger.LogInformation(LoggingEvents.Logout, "User logged out.");
            
            return Ok();
        }

    }
}