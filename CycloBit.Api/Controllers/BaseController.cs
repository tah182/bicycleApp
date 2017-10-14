using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CycloBit.Api.Attributes;
using CycloBit.Model;

namespace CycloBit.Api.Controllers {
    [ValidateModel]
    public abstract class BaseController<T> : Controller {
        
        protected readonly ILogger<T> Logger;
        protected CycloBitContext db { get; private set; }

        protected BaseController (ILogger<T> logger, CycloBitContext db) {
            this.Logger = logger;
            this.db = db;
        }

        protected override void Dispose(bool disposing) {
            if (!disposing) return;

            if(this.db != null) {
                this.db.Dispose();
                this.db = null;
            }

            base.Dispose(disposing);
        }
    }
}