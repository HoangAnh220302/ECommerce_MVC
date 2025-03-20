using System.ComponentModel.DataAnnotations;

namespace ECommerce_MVC.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20,ErrorMessage = "20 characters maximum")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
