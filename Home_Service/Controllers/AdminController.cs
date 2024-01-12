using Microsoft.AspNetCore.Mvc;

namespace Home_Service.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
