﻿using Microsoft.AspNetCore.Mvc;
using Home_Service.Models;
using Home_Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Home_Service.Servicelayer;

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
            RejectedServices = _adminService.GetRejectedServices(),
            ReapprovalRequests = _adminService.GetReapprovalRequests()
        };

        return View(viewModel);
    }
    public IActionResult ManageCategories()
    {
        var viewModel = new AdminViewModel
        {
            Categories = _adminService.GetCategories(),
        };

        return View(viewModel);
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
            var viewModel = new AdminViewModel
            {
                RejectedServiceDetails = service
            };
            return View(viewModel);
        }

        return RedirectToAction("NewServices");
    }

    [HttpPost]
    public IActionResult RejectService(int id, string adminComment)
    {
        _adminService.RejectService(id, adminComment);
        return RedirectToAction("NewServices");
    }

    public IActionResult RejectedServices()
    {
        var viewModel = new AdminViewModel
        {
            RejectedServices = _adminService.GetRejectedServices()
        };

        return View(viewModel);
    }
    public IActionResult ApprovedServices()
    {
        var viewModel = new AdminViewModel
        {
            ApprovedServices = _adminService.GetApprovedServices()
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
    public IActionResult ApproveRejectedService(int id)
    {
        _adminService.ApproveRejectedService(id);
        var approvedService = _adminService.GetReapprovedServices(id);

        if (approvedService != null)
        {
            return RedirectToAction("ApprovedServices");
        }
        else
        {
            return RedirectToAction("ManageCategories");
        }
    }
    public IActionResult ReapprovalRequests()
    {
        var viewModel = new AdminViewModel
        {
            ReapprovalRequests = _adminService.GetReapprovalRequests(),
            ReapprovalRequestsCount = _adminService.GetReapprovalRequestsCount()
        };
        return View(viewModel);
    }
}
