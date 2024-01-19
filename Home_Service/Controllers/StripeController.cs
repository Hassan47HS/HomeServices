using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Home_Service.Models;
using Home_Service.ViewModel;
using Home_Service.ServiceLayer;
using Home_Service;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Stripe;
using Stripe.Checkout;
using Home_Service.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace Home_Service.Controllers
{
    public class StripeController : Controller
    {
        private readonly StripeSettings _stripeSettings;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly HomeServiceDB _context;
        private readonly IStripeService stripeService;

        public string SessionId { get; set; }

        public StripeController(IOptions<StripeSettings> stripeSettings,UserManager<IdentityUser> userManager, HomeServiceDB context, IStripeService _stripeService)
        {
            _stripeSettings = stripeSettings.Value;
            _userManager = userManager;
            _context = context;
            stripeService = _stripeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateCheckoutSession(int serviceId)
        {
            var currency = "usd";
            var successUrl = Url.Action("Success", "Stripe", new { serviceId }, Request.Scheme);
            var cancelUrl = Url.Action("Cancel", "Stripe", null, Request.Scheme);

            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            var service = _context.services.Include(s => s.User).Include(s => s.Category).FirstOrDefault(s => s.Id == serviceId);
            if (service == null)    
            {
                return NotFound();
            }
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = currency,
                            UnitAmount = (long)(service.Price * 100),  
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = service.Title,
                                Description = service.Description
                            }
                        },
                        Quantity = 1
                    }
            },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };
            var _sessionService = new SessionService();
            var session = _sessionService.Create(options);
            SessionId = session.Id;

            return Redirect(session.Url);

        }

        [Authorize]
        public async Task<IActionResult> Success(int serviceId)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            stripeService.BookService(serviceId, userId);
            return RedirectToAction("ViewOngoingServices", "Customer");
        }

        [Authorize]
        public IActionResult Cancel()   
        {
            return View("Index");
        }
    }

}
