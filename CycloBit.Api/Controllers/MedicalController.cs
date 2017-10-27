using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Binding;
using CycloBit.Api.Model;
using CycloBit.Business.Services;
using CycloBit.Common.Objects;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Controllers {
    [Route("[controller]")]
    [Authorize]
    public class MedicalController : BaseController<MedicalController> {
        #region private helpers
        private UserManager<ApplicationUser> UserManager;

        private MedicalService medicalService = null;
        protected MedicalService MedicalService {
            get {
                if (this.medicalService == null)
                    this.medicalService = new MedicalService(this.db);

                return this.medicalService;
            }
        }
        #endregion
        
        public MedicalController(ILogger<MedicalController> logger,
                                 UserManager<ApplicationUser> userManager,
                                 CycloBitContext db) : base(logger, db) { 
            this.UserManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool empirical = false) {
            var user = await this.UserManager.GetUserAsync(this.User);
            var medicalDetail = await this.MedicalService.GetAsync(user.Id);
            
            return Ok((IMedicalDetail)medicalDetail);
        }

        [HttpPost]
        public IActionResult Post(MedicalBindingModel model) {
            throw new NotImplementedException();   // make controller async
        }

        [HttpPut]
        public IActionResult Put(MedicalBindingModel model) {
            throw new NotImplementedException();   // make controller async
        }

        [HttpDelete]
        public IActionResult Delete() {
            return NotFound();
        }

        protected override void Dispose(bool disposing) {
            if (!disposing) return;
            
            if (this.MedicalService != null) {
                this.MedicalService.Dispose();
                this.medicalService = null;
            }

            base.Dispose(disposing);
        }
    }
}