using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Attributes;
using CycloBit.Api.Model;

namespace CycloBit.Api.Controllers {
    [ValidateModel]
    public abstract class BaseController<T> : Controller {
        
        protected ILogger<T> Logger { get; set; }
        protected CycloBitContext db { get; set; }

        protected BaseController (ILogger<T> logger, CycloBitContext db) {
            this.Logger = logger;
            this.db = db;
        }
    }
}