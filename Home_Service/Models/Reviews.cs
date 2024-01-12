using System.ComponentModel.DataAnnotations.Schema;

namespace Home_Service.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int rating { get; set; }
        public string Comment { get; set; } = "";
        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public Services services { get; set; }
    }
}
