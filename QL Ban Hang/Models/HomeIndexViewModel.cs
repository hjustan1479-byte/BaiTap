namespace QL_Ban_Hang.Models;

public class HomeIndexViewModel
{
    public IReadOnlyList<Book> Books { get; init; } = [];
    public IReadOnlyList<CategoryCountViewModel> Categories { get; init; } = [];
}

public class CategoryCountViewModel
{
    public string Category { get; init; } = string.Empty;
    public int Count { get; init; }
}
