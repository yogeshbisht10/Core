using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
