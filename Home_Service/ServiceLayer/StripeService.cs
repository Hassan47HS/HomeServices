using Home_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Home_Service.ServiceLayer
{
    public class StripeService:IStripeService
    {
        private readonly HomeServiceDB _context;

        public StripeService(HomeServiceDB context)
        {
            _context = context;
        }
        public void BookService(int serviceId, string userId)
        {
            var service = _context.services.Find(serviceId);
            if (service != null && service.Status == Status.Approve)
            {
                var booking = new Booking
                {
                    ServiceId = serviceId,
                    UserId = userId,
                    BookingDate = DateTime.Now,
                    serviceStatus = ServiceStatus.ongoing
                };
                _context.bookings.Add(booking);
                _context.SaveChanges();
            }
        }
    }
}
