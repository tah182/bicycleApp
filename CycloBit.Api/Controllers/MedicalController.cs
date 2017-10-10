using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Binding;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Controllers {
    [Route("[controller]")]
    [Authorize]
    public class MedicalController : BaseController<AccountController> {
        public MedicalController(ILogger<AccountController> logger,
                                 CycloBitContext db) : base(logger, db) { }

        public IActionResult Post([FromBody] MedicalBindingModel model) {
            throw new NotImplementedException();   // make controller async
        }
    }
}