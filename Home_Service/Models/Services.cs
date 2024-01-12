using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Home_Service.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Price {  get; set; }
        public double AverageRating { get; set; }

        public string UserId { get; set; }  // This property represents the foreign key
        [ForeignKey("UserId")]
        public User User { get; set; }  // Navigation property

        public int CategoryId { get; set; }//Fk
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }//navigation Property
        [ForeignKey("SerivceId")]
        public ICollection<Reviews> Reviews { get; set; }//Navigation Property
        public string RejectionReason { get; set; } = "";
        public bool IsReApprovalRequested { get; set; }
        public Status Status { get; set; }
        public string AdminComment { get; set; } = "";

    }
}   