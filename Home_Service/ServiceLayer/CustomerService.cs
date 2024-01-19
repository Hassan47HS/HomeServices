using System.Collections.Generic;
using System.Linq;
using Home_Service.Migrations;
using Home_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Home_Service.ServiceLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly HomeServiceDB _context;

        public CustomerService(HomeServiceDB context)
        {
            _context = context;
        }

        public List<Services> GetAllServices()
        {
            return _context.services.ToList();
        }
        public List<Services> GetAllAvailableServices()
        {
            return _context.services
                .Include(s=>s.Category)
                .Where(s => s.Status == Status.Approve)
                .ToList();
        }
        public Services GetServiceDetails(int serviceId)
        {
            return _context.services
                .Include(s => s.Reviews)
                .Include(s=>s.Category)
                .FirstOrDefault(s => s.Id == serviceId);
        }
        public List<Services> GetOngoingServices()
        {
            return _context.services
                .Include(s=>s.Category)
                .Where(s => s.Status == Status.Approve)
                .ToList();
        }
        public List<Services> GetCompletedServices()
        {
            return _context.services.Include(s=>s.Category)
                .Where(s => s.Status == Status.Approve && s.Reviews.Any())
                .ToList();
        }
        public List<Booking> getongoingbookings()
        {
            return _context.bookings
                .Include(s=>s.Service)
               .Where(s => s.serviceStatus == ServiceStatus.ongoing)
               .ToList();
        }
        public List<Booking> getCompleteBookings()
        {
            return _context.bookings.Include(s=>s.Service).Where(s=>s.serviceStatus == ServiceStatus.compelete).ToList();
        }
        public List<Services> SortServicesByDate(List<Services> services)
        {
            // Sorting services by the Date property in ascending order
            var sortedServices = services.OrderBy(s => s.Date).ToList();

            return sortedServices;
        }
        public List<Services> SearchServicesByCategory(int categoryId)
        {
            var servicesByCategory = _context.services
                .Include(s => s.Category)
                .Where(s => s.CategoryId == categoryId && s.Status == Status.Approve)
                .ToList();

            return servicesByCategory;
        }
        public List<Category> GetAllCategories()
        {
            return _context.categories.ToList();
        }
        public void SubmitRatingAndReviews(int rate, string comment, int bookingid)
        {
            var booking = _context.bookings.Find(bookingid);
            if (booking != null)
            {
                var reviews = new Reviews
                {
                    rating = rate,
                    Comment = comment,
                    ServiceId = booking.ServiceId
                };
                var service = _context.services.Include(s=>s.Reviews).FirstOrDefault(s=>s.Id==booking.ServiceId);
                if (service != null)
                {
                    service.AverageRating = (service.AverageRating + reviews.rating) / 2;
                    service.Reviews.Add(reviews);
                }
                _context.SaveChanges();
            }
        }
        public void UpdateBookingStatusToComplete(int bookingId)
        {
            var booking = _context.bookings.Find(bookingId);

            if (booking != null)
            {
                booking.serviceStatus = ServiceStatus.compelete;
                _context.SaveChanges();
            }
        }
    }
}
