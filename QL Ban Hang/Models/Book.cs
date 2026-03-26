namespace QL_Ban_Hang.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public int ReviewCount { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
