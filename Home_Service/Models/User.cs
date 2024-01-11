using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Home_Service.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public Role Role { get; set; }

        public Status Status { get; set; }
    }


public enum Gender
    {
        Male, 
        Female
    }
    public enum Role
    {
        Seller,
        Customer
    }   
    public enum Status
    {
        Pending,
        Approve, 
        Reject
    }
}
