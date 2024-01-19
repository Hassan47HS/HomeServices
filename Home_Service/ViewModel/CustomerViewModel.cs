    using Home_Service.Migrations;
    using Home_Service.Models;

    namespace Home_Service.ViewModel
    {
        public class CustomerViewModel
        {
            public List<Services> services { get; set; }
            public List<Category> categories {  get; set; }  
            public List<Booking>? bookings { get; set; }
        public int? BookingId { get; set; }
        }
    }