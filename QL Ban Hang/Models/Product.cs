using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ban_Hang.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
    [StringLength(200)]
    [Display(Name = "Tên sản phẩm")]
    public string Name { get; set; } = string.Empty;

    [StringLength(150)]
    [Display(Name = "Tác giả / Thương hiệu")]
    public string? Author { get; set; }

    [Display(Name = "Mô tả")]
    [StringLength(2000)]
    public string? Description { get; set; }

    [Display(Name = "Giá bán")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 1000000000)]
    public decimal Price { get; set; }

    [Display(Name = "Giá gốc")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 1000000000)]
    public decimal OriginalPrice { get; set; }

    [StringLength(500)]
    [Display(Name = "Ảnh sản phẩm")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Chủ đề")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
