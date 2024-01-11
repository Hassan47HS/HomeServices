using Microsoft.AspNetCore.Mvc;
using Home_Service.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host.Mef;

namespace Home_Service.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceLayer service;
        public ServiceController(ServiceLayer _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            var services = service.GetAllServices();
            return View(services);
        }
        public IActionResult Details(int id)
        {
            var services = service.GetServiceById(id);
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
            service.CreateService(servicing);
            return RedirectToAction("Index","Service");
        }
    }
}
