namespace QL_Ban_Hang.Models;

public class HomeIndexViewModel
{
    public IReadOnlyList<Product> Products { get; init; } = [];
    public IReadOnlyList<CategorySummaryViewModel> Categories { get; init; } = [];
    public int? SelectedCategoryId { get; init; }
    public string? SelectedCategoryName { get; init; }
}

public class CategorySummaryViewModel
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int ProductCount { get; init; }
}
