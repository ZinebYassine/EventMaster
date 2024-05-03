using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BookEventController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
