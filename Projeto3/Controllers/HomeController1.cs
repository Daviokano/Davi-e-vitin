using Microsoft.AspNetCore.Mvc;

namespace Projeto3.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
