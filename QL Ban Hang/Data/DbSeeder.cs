using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QL_Ban_Hang.Models;

namespace QL_Ban_Hang.Data;

public static class DbSeeder
{
    private const string AdminRole = "Admin";
    private const string MemberRole = "Member";
    private const string AdminUserName = "admin";
    private const string MemberUserName = "member";
    private const string DefaultPassword = "123456";

    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        await EnsureRoleAsync(roleManager, AdminRole);
        await EnsureRoleAsync(roleManager, MemberRole);

        await EnsureUserAsync(
            userManager,
            AdminUserName,
            "Quản trị viên",
            "TP.HCM",
            AdminRole);

        await EnsureUserAsync(
            userManager,
            MemberUserName,
            "Thành viên mẫu",
            "Hà Nội",
            MemberRole);

        if (await context.Categories.AnyAsync())
        {
            return;
        }

        var lifeCategory = new Category
        {
            Name = "Cuộc sống",
            Description = "Những đầu sách truyền cảm hứng và kỹ năng sống."
        };

        var programmingCategory = new Category
        {
            Name = "Lập trình",
            Description = "Các đầu sách dành cho sinh viên CNTT và lập trình viên."
        };

        var healthCategory = new Category
        {
            Name = "Sức khỏe",
            Description = "Sách về dinh dưỡng, lối sống và chăm sóc bản thân."
        };

        context.Categories.AddRange(lifeCategory, programmingCategory, healthCategory);

        context.Products.AddRange(
            new Product
            {
                Name = "Cho Tôi Xin Một Vé Đi Tuổi Thơ",
                Author = "Nguyễn Nhật Ánh",
                Description = "Tác phẩm nổi tiếng gợi lại thế giới tuổi thơ trong trẻo, hồn nhiên và giàu cảm xúc.",
                Price = 61600,
                OriginalPrice = 80000,
                ImageUrl = "/images/books/cho-toi-xin-mot-ve-di-tuoi-tho.svg",
                Category = lifeCategory
            },
            new Product
            {
                Name = "Cuộc Sống Rất Giống Cuộc Đời",
                Author = "Hải Đỗ",
                Description = "Cuốn sách chia sẻ góc nhìn nhẹ nhàng và thực tế về cách sống, cách đối diện và trưởng thành.",
                Price = 61000,
                OriginalPrice = 90000,
                ImageUrl = "/images/books/cuoc-song-rat-giong-cuoc-doi.svg",
                Category = lifeCategory
            },
            new Product
            {
                Name = "Lập Trình C Cơ Bản",
                Author = "Lê Xuân Việt",
                Description = "Giáo trình nhập môn ngôn ngữ C với cú pháp, mảng, hàm và bài tập thực hành nền tảng.",
                Price = 89000,
                OriginalPrice = 120000,
                ImageUrl = "/images/books/lap-trinh-c-co-ban.svg",
                Category = programmingCategory
            },
            new Product
            {
                Name = "Core Java Fundamentals",
                Author = "Cay S. Horstmann",
                Description = "Tổng hợp kiến thức nền tảng Java như class, object, collection và exception handling.",
                Price = 135000,
                OriginalPrice = 165000,
                ImageUrl = "/images/books/core-java-fundamentals.svg",
                Category = programmingCategory
            },
            new Product
            {
                Name = "Sức Khỏe Từ Gốc",
                Author = "Ngô Đức Hùng",
                Description = "Sách cung cấp kiến thức chăm sóc sức khỏe chủ động từ dinh dưỡng đến lối sống.",
                Price = 72000,
                OriginalPrice = 99000,
                ImageUrl = "/images/books/suc-khoe-tu-goc.svg",
                Category = healthCategory
            });

        await context.SaveChangesAsync();
    }

    private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task EnsureUserAsync(
        UserManager<ApplicationUser> userManager,
        string userName,
        string fullName,
        string address,
        string roleName)
    {
        var user = await userManager.FindByNameAsync(userName);
        if (user is null)
        {
            user = new ApplicationUser
            {
                UserName = userName,
                FullName = fullName,
                Address = address,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(user, DefaultPassword);
            if (!createResult.Succeeded)
            {
                var errors = string.Join("; ", createResult.Errors.Select(error => error.Description));
                throw new InvalidOperationException($"Không thể tạo tài khoản {userName}: {errors}");
            }
        }

        if (!await userManager.IsInRoleAsync(user, roleName))
        {
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
