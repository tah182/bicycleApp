using System;
using Xunit;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BicycleApi.Binding;
using BicycleApi.Factory;
using BicycleApi.Logging;
using BicycleApi.Model;
using BicycleApi.Service;

using Moq;

namespace CycloBit.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public void RegisterTest() {  
            // UserManager<ApplicationUser> userManager, X
            // SignInManager<ApplicationUser> signInManager, 
            // ILogger<AccountController> logger, 
            // BicycleContext db,
            // IEmailService emailService
            throw new NotImplementedException();
        }

        [Fact]
        public void LoginTest() {  
            throw new NotImplementedException();
        }

        [Fact]
        public void ForgotPasswordTest() {  
            throw new NotImplementedException();
        }

        [Fact]
        public void LogoutTest() {  
            throw new NotImplementedException();
        }

        public UserManager<ApplicationUser> mockUserManager() { 
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            return new UserManager<ApplicationUser>(userStore.Object, null, null, null, null, null, null, null, null);
        }
    }
}
