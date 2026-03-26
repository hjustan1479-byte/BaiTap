using System.ComponentModel.DataAnnotations;

namespace QL_Ban_Hang.Models;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên chủ đề.")]
    [StringLength(100)]
    [Display(Name = "Tên chủ đề")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
