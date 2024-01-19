using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Home_Service.Migrations;
using Home_Service.Models;
using Home_Service.ServiceLayer;
using Home_Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

[Authorize(Roles = "Customer")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly StripeSettings _stripeSettings;

    public CustomerController(ICustomerService customerService, IOptions<StripeSettings> stripeSettings)
    {
        _customerService = customerService;
        _stripeSettings = stripeSettings.Value;
    }
    public IActionResult ViewServices()
    {
        var availableServices = _customerService.GetAllAvailableServices();
        var categories = _customerService.GetAllCategories();

        var viewModel = new CustomerViewModel
        {
            services = availableServices,
            categories = categories
        };
        return View(viewModel);
    }

    public IActionResult ViewServiceDetail(int id)
    {
        var serviceDetail = _customerService.GetServiceDetails(id);
        var categories = _customerService.GetAllCategories();
        var viewModel = new CustomerViewModel
        {
            services = new List<Services> { serviceDetail },
            categories = categories
        };
        return View(viewModel);
    }
    [HttpPost]
    public IActionResult SortServicesByDate(List<Services> services)
    {
        var sortedServices = _customerService.SortServicesByDate(services);
        var viewModel = new CustomerViewModel
        {
            services = sortedServices
        };
        return View("ViewServices", viewModel);
    }
    public IActionResult SearchServicesByCategory(int categoryId)
    {
        var servicesByCategory = _customerService.SearchServicesByCategory(categoryId);
        var categories = _customerService.GetAllCategories();

        var viewModel = new CustomerViewModel
        {
            services = servicesByCategory,
            categories = categories
        };

        return View("ViewServices", viewModel);
    }
    public IActionResult ViewOngoingServices()
    {
        var ongoingBookings = _customerService.getongoingbookings();
        var categories = _customerService.GetAllCategories();
        var viewModel = new CustomerViewModel
        {
            bookings = ongoingBookings,
            categories = categories
        };
        return View(viewModel);
    }

    public IActionResult ViewCompletedServices()
    {
        var completedBookings = _customerService.getCompleteBookings();
        var categories = _customerService.GetAllCategories();
        var viewModel = new CustomerViewModel
        {
            bookings = completedBookings,
            categories = categories
        };
        return View(viewModel);
    }
    public IActionResult BookService(int serviceId)
    {
        var serviceDetail = _customerService.GetServiceDetails(serviceId);
        var categories = _customerService.GetAllCategories();
        var viewModel = new CustomerViewModel
        {
            services = new List<Services> { serviceDetail },
            categories = categories
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult SubmitRatingAndReviews(int bookingId)
    {
        var categories = _customerService.GetAllCategories();
        var viewModel = new CustomerViewModel
        {
            categories = categories,
            BookingId = bookingId
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SubmitRatingAndReviews(int rate, string comment, int bookingId)
    {
        _customerService.SubmitRatingAndReviews(rate, comment, bookingId);
        _customerService.UpdateBookingStatusToComplete(bookingId);

        return RedirectToAction("ViewServices");
    }
}