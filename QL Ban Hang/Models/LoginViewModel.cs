using System.ComponentModel.DataAnnotations;

namespace QL_Ban_Hang.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập UserName.")]
    [Display(Name = "UserName")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Ghi nhớ đăng nhập")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}
