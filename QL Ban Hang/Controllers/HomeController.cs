using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_Ban_Hang.Data;
using QL_Ban_Hang.Models;
using System.Diagnostics;

namespace QL_Ban_Hang.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? categoryId)
    {
        var categories = await _context.Categories
            .OrderBy(category => category.Name)
            .Select(category => new CategorySummaryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ProductCount = category.Products.Count
            })
            .ToListAsync();

        var productsQuery = _context.Products
            .Include(product => product.Category)
            .AsQueryable();

        if (categoryId.HasValue)
        {
            productsQuery = productsQuery.Where(product => product.CategoryId == categoryId.Value);
        }

        var products = await productsQuery
            .OrderBy(product => product.Name)
            .ToListAsync();

        var model = new HomeIndexViewModel
        {
            Categories = categories,
            Products = products,
            SelectedCategoryId = categoryId,
            SelectedCategoryName = categories.FirstOrDefault(category => category.Id == categoryId)?.Name
        };

        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(item => item.Category)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
