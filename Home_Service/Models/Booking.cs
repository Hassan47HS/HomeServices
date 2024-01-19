using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home_Service.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Services Service { get; set; }

        [ForeignKey("User")]    
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }   
        public ServiceStatus serviceStatus { get; set; }
    }
    public enum ServiceStatus
    {
        ongoing,
        compelete
    }
}
