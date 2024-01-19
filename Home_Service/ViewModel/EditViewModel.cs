using Home_Service.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Home_Service.ViewModel
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public double AverageRating { get; set; }
        public string ReapprovalRequestMessage { get; set; }
        //public Category Category { get; set; }
        public int SelectedCategoryId { get; set; }
        public List<SelectListItem>? AvailableCategories { get; set; } 
        public bool IsReApprovalRequested { get; set; }
        public Status Status { get; set; }
        public string AdminComment { get; set; } = "";


    }
}
