using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Binding;
using CycloBit.Model;
using CycloBit.Model.Entities;

namespace CycloBit.Api.Controllers {
    [Route("[controller]")]
    public class MedicalController : BaseController<AccountController> {
        public MedicalController(ILogger<AccountController> logger,
                                 CycloBitContext db) : base(logger, db) { }

        public async IActionResult Post([FromBody] MedicalBindingModel model) {
            return Ok();
        }
    }
}