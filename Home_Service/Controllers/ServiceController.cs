using Microsoft.AspNetCore.Mvc;
using Home_Service.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host.Mef;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Home_Service.Controllers
{
    public class ServiceController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ServiceLayer service;
        public ServiceController(ServiceLayer _service , UserManager<IdentityUser> userManager)
        {
            service = _service;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var services = service.GetAllServiceForUser(userId);
            return View(services);
        }
        public IActionResult Details(int id)
        {
            var services = service.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(services);
        }
        public IActionResult ResolveComments(int id) 
        {
            var services = service.GetServiceById(id);
            return View(services);
        }
        [HttpPost]
        public IActionResult ResolveComments(int id, string adminComments) 
        {
            service.ResolveComments(id, adminComments);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            ViewBag.Categories = service.GetAllCategories()
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services servicing)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                service.CreateService(servicing, userId);
            }
            
            return RedirectToAction("Index", "Service");
        }
    }
}
