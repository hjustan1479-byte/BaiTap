namespace QL_Ban_Hang.Models;

public static class BookRepository
{
    private static readonly IReadOnlyList<Book> Books =
    [
        new Book
        {
            Id = 1,
            Title = "Cho Tôi Xin Một Vé Đi Tuổi Thơ",
            Author = "Nguyễn Nhật Ánh",
            Category = "Cuộc sống",
            Description = "Tác phẩm nổi tiếng mang màu sắc trong trẻo, kể lại thế giới tuổi thơ bằng góc nhìn hồn nhiên và gần gũi.",
            Price = 61600,
            OriginalPrice = 80000,
            ReviewCount = 79,
            Publisher = "NXB Trẻ",
            ImageUrl = "/images/books/cho-toi-xin-mot-ve-di-tuoi-tho.svg"
        },
        new Book
        {
            Id = 2,
            Title = "Cuộc Sống Rất Giống Cuộc Đời",
            Author = "Hải Đỗ",
            Category = "Cuộc sống",
            Description = "Cuốn sách truyền cảm hứng về cách sống tích cực, biết quan sát bản thân và nhìn đời bằng thái độ bình tĩnh, chủ động hơn.",
            Price = 61000,
            OriginalPrice = 90000,
            ReviewCount = 45,
            Publisher = "NXB Thanh Niên",
            ImageUrl = "/images/books/cuoc-song-rat-giong-cuoc-doi.svg"
        },
        new Book
        {
            Id = 3,
            Title = "Lập Trình C Cơ Bản",
            Author = "Lê Xuân Việt",
            Category = "Lập trình",
            Description = "Tài liệu nhập môn giúp người học nắm cú pháp, cấu trúc điều khiển, hàm và mảng trong ngôn ngữ C.",
            Price = 89000,
            OriginalPrice = 120000,
            ReviewCount = 31,
            Publisher = "NXB Giáo Dục",
            ImageUrl = "/images/books/lap-trinh-c-co-ban.svg"
        },
        new Book
        {
            Id = 4,
            Title = "Core Java Fundamentals",
            Author = "Cay S. Horstmann",
            Category = "Lập trình",
            Description = "Tổng hợp kiến thức nền tảng về Java như class, object, collection và xử lý ngoại lệ, phù hợp cho người học nâng cao.",
            Price = 135000,
            OriginalPrice = 165000,
            ReviewCount = 26,
            Publisher = "Oracle Press",
            ImageUrl = "/images/books/core-java-fundamentals.svg"
        },
        new Book
        {
            Id = 5,
            Title = "Sức Khỏe Từ Gốc",
            Author = "Ngô Đức Hùng",
            Category = "Sức khỏe",
            Description = "Sách chia sẻ kiến thức chăm sóc sức khỏe chủ động, kết hợp dinh dưỡng, vận động và thói quen sinh hoạt lành mạnh.",
            Price = 72000,
            OriginalPrice = 99000,
            ReviewCount = 18,
            Publisher = "NXB Y Học",
            ImageUrl = "/images/books/suc-khoe-tu-goc.svg"
        }
    ];

    public static IReadOnlyList<Book> GetAll() => Books;

    public static Book? GetById(int id) => Books.FirstOrDefault(book => book.Id == id);

    public static IReadOnlyList<CategoryCountViewModel> GetCategoryCounts() =>
        Books.GroupBy(book => book.Category)
            .Select(group => new CategoryCountViewModel
            {
                Category = group.Key,
                Count = group.Count()
            })
            .OrderBy(item => item.Category)
            .ToList();
}
