using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Binding;
using CycloBit.Model;

namespace CycloBit.Api.Controllers {
    [Route("[controller]")]
    [Authorize]
    public class LocationController : BaseController<LocationController> {
        
        public LocationController(ILogger<LocationController> logger,
                                  CycloBitContext db) : base(logger, db) { }

        public IActionResult Get() {
            throw new NotImplementedException();   // make controller async
        }

    }
}