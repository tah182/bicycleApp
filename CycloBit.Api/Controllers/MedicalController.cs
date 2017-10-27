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
        public async Task<IActionResult> Get() {
            var user = await currentUser();
            var medicalDetail = await this.MedicalService.GetAsync(user.Id);
            
            return Ok((IMedicalDetail)medicalDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicalBindingModel model) {
            var user = await this.UserManager.GetUserAsync(this.User);
            var updatedDetail = convertBindingToEntity(model, user);

            await this.MedicalService.UpdateAsync(updatedDetail);
            user.DateOfBirth = model.DateOfBirth;
            var result = await this.UserManager.UpdateAsync(user);

            return Ok(result.Succeeded);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MedicalBindingModel model) {
            var user = await currentUser();
            var newDetail = convertBindingToEntity(model, user);

            await this.MedicalService.AddAsync(newDetail);
            user.DateOfBirth = model.DateOfBirth;
            var result = await this.UserManager.UpdateAsync(user);

            return Ok(result.Succeeded);
        }

        [HttpDelete]
        public IActionResult Delete() {
            return NotFound();
        }

        private async Task<ApplicationUser> currentUser() {
            return await this.UserManager.GetUserAsync(this.User);
        }

        private MedicalDetail convertBindingToEntity(MedicalBindingModel model, ApplicationUser user) {
            return new MedicalDetail {
                IdentityUserId = user.Id,
                HeightCm = model.HeightCm,
                WeightKg = model.WeightKg
            };
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