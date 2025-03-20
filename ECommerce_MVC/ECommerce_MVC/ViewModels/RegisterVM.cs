using System.ComponentModel.DataAnnotations;

namespace ECommerce_MVC.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Customer ID is required")]
        [MaxLength(20,ErrorMessage = "20 characters maximum")]
        public string MaKh { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Customer password is required")]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "50 characters maximum")]
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; } = true;

        public DateTime? NgaySinh { get; set; }

        [MaxLength(60, ErrorMessage = "60 characters maximum")]
        public string? DiaChi { get; set; }

        [MaxLength(24, ErrorMessage = "24 characters maximum")]
        [RegularExpression(@"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$")]
        public string? DienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Incorrect email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$")]
        public string Email { get; set; }
        public string? Hinh { get; set; }
    }
}
