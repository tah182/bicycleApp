using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Binding;
using CycloBit.Business.Services;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Controllers {
    [Route("[controller]")]
    [Authorize]
    public class MedicalController : BaseController<AccountController> {
        private MedicalService medicalService = null;
        protected MedicalService MedicalService {
            get {
                if (this.medicalService == null)
                    this.medicalService = new MedicalService(this.User, this.db);

                return this.medicalService;
            }
        }
        
        public MedicalController(ILogger<AccountController> logger,
                                 CycloBitContext db) : base(logger, db) { }

        public IActionResult Get([FromBody] MedicalBindingModel model) {
            throw new NotImplementedException();   // make controller async
        }

        public IActionResult Post([FromBody] MedicalBindingModel model) {
            throw new NotImplementedException();   // make controller async
        }

        public IActionResult Put([FromBody] MedicalBindingModel model) {
            throw new NotImplementedException();   // make controller async
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