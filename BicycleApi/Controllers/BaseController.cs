using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BicycleApi.Attributes;
using BicycleApi.Model;

namespace BicycleApi.Controllers {
    [ValidateModel]
    public abstract class BaseController<T> : Controller {
        
        protected ILogger<T> Logger { get; set; }
        protected BicycleContext db { get; set; }

        protected BaseController (ILogger<T> logger, BicycleContext db) {
            this.Logger = logger;
            this.db = db;
        }
    }
}