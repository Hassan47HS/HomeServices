using Home_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace Home_Service.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public Role Role { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName {  get; set; }
    }
}
