using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Shared
{
    public class EntityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
