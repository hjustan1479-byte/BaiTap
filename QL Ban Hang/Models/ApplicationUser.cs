using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QL_Ban_Hang.Models;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
    [StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
    [StringLength(255)]
    public string Address { get; set; } = string.Empty;
}
