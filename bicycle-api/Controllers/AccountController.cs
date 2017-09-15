using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BicycleApi.Model;

namespace BicycleApi.Controllers {
    [Route("[controller]")]
    public class AccountController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] ApplicationUser model) {
            return Ok();
        }
    }
}