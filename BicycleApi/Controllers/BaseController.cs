using Microsoft.AspNetCore.Mvc;
using BicycleApi.Attributes;

namespace BicycleApi.Controllers {
    [ValidateModel]
    public abstract class BaseController : Controller {
        
    }
}