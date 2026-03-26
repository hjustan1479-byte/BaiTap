using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_Ban_Hang.Data;

namespace QL_Ban_Hang.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.CategoryCount = _context.Categories.Count();
        ViewBag.ProductCount = _context.Products.Count();
        ViewBag.MemberCount = _context.Users.Count();
        return View();
    }
}
