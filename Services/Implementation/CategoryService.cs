namespace InventoryManagement.Implementation.Services;

using Microsoft.EntityFrameworkCore;
using InventoryManagement.Dtos;
using InventoryManagement.Models;
using InventoryManagement.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        return await _context.Categories
            .Include(c => c.Products)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
{
    var category = new Category
    {
        Name = dto.Name
    };

    _context.Categories.Add(category);
    await _context.SaveChangesAsync();

    return new CategoryDto
    {
        Id = category.Id,
        Name = category.Name,
        Products = new List<ProductDto>()
    };
}
}
