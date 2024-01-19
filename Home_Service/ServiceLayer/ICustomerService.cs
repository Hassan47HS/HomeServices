using Home_Service.Migrations;
using Home_Service.Models;
using System.Collections.Generic;

namespace Home_Service.ServiceLayer
{
    public interface ICustomerService
    {
        List<Services> GetAllServices();
        List<Services> GetAllAvailableServices();
        Services GetServiceDetails(int serviceId);
        List<Services> GetOngoingServices();
        List<Services> GetCompletedServices();
        List<Booking> getongoingbookings();
        List<Booking> getCompleteBookings();
        //void SubmitReview(Reviews review);
        List<Services> SortServicesByDate(List<Services> services);
        List<Services> SearchServicesByCategory(int categoryId);
        List<Category> GetAllCategories();
        void SubmitRatingAndReviews(int rate, string comment, int bookingid);
        void UpdateBookingStatusToComplete(int bookingId);
    }
}

