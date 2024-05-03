using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class VenueController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
