using Home_Service.Models;

namespace Home_Service.ViewModel
{
    public class AdminViewModel
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public List<Services> NewServices { get; set; }
        public List<Services> ApprovedServices { get; set; }
        public List<Services> RejectedServices { get; set; }
        public Services RejectedServiceDetails { get; set; }

    }
}
