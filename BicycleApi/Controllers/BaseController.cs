using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BicycleApi.Attributes;

namespace BicycleApi.Controllers {
    [ValidateModel]
    public abstract class BaseController<T> : Controller {
        
        protected ILogger<T> Logger { get; set; }

        protected BaseController (ILogger<T> logger) {
            this.Logger = logger;
        }

    }
}