using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CustomerController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
