using System.ComponentModel.DataAnnotations;

namespace ECommerce_MVC.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "*")]
        [MaxLength(20,ErrorMessage = "20 characters maximum")]
        public string MaKh { get; set; }

        [Required(ErrorMessage = "*")]
        public string? MatKhau { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "50 characters maximum")]
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; } = true;

        public DateTime? NgaySinh { get; set; }

        [MaxLength(60, ErrorMessage = "60 characters maximum")]
        public string? DiaChi { get; set; }

        [MaxLength(24, ErrorMessage = "24 characters maximum")]
        public string? DienThoai { get; set; }

        public string Email { get; set; }

        [EmailAddress(ErrorMessage = "")]
        public string? Hinh { get; set; }
    }
}
