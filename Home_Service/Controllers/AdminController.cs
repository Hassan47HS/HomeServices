using Microsoft.AspNetCore.Mvc;
using Home_Service.Models;
using Home_Service.ServiceLayer;
using Home_Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IActionResult Dashboard()
    {
        var viewModel = new AdminViewModel
        {
            Categories = _adminService.GetCategories(),
            NewServices = _adminService.GetNewServices(),
            ApprovedServices = _adminService.GetApprovedServices(),
            RejectedServices = _adminService.GetRejectedServices()
        };

        return View(viewModel);
    }

    public IActionResult ManageCategories()
    {
        List<Category> categories = _adminService.GetCategories();
        return View(categories);
    }

    public IActionResult AddCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            _adminService.AddCategory(category);
            return RedirectToAction("ManageCategories");
        }
        return View(category);
    }

    public IActionResult DeleteCategory(int id)
    {
        _adminService.DeleteCategory(id);
        return RedirectToAction("ManageCategories");
    }

    public IActionResult NewServices()
    {
        var viewModel = new AdminViewModel
        {
            NewServices = _adminService.GetNewServices()
        };

        return View(viewModel);
    }

    public IActionResult ApproveService(int id)
    {
        _adminService.ApproveService(id);
        return RedirectToAction("NewServices");
    }

    public IActionResult RejectService(int id)
    {
        var service = _adminService.GetRejectedService(id);
        if (service != null)
        {
            return View(service);
        }
        return RedirectToAction("NewServices");
    }

    [HttpPost]
    public IActionResult RejectService(int id, string rejectionReason)
    {
        _adminService.RejectService(id, rejectionReason);
        return RedirectToAction("NewServices");
    }

    public IActionResult ApprovedServices()
    {
        var viewModel = new AdminViewModel
        {
            ApprovedServices = _adminService.GetApprovedServices()
        };

        return View(viewModel);
    }

    public IActionResult RejectedServices()
    {
        var viewModel = new AdminViewModel
        {
            RejectedServices = _adminService.GetRejectedServices()
        };

        return View(viewModel);
    }

    public IActionResult ViewRejectedService(int id)
    {
        var viewModel = new AdminViewModel
        {
            RejectedServiceDetails = _adminService.GetRejectedService(id)
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ApproveRejectedService(int id)
    {
        _adminService.ApproveRejectedService(id);
        return RedirectToAction("RejectedServices");
    }
}
