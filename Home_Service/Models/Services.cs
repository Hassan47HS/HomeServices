using System.ComponentModel.DataAnnotations.Schema;

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
        public int CategoryId { get; set; }//Fk
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }//navigation Property
        public Status Status { get; set; }
        public string AdminComment { get; set; } = "";

    }
}   