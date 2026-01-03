namespace InventoryManagement.Implementation.Services;

using InventoryManagement.Dtos;
using InventoryManagement.Exceptions;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            })
            .ToListAsync();
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        // Business rule: category must exist
        var categoryExists = await _context.Categories
            .AnyAsync(c => c.Id == dto.CategoryId);

        if (!categoryExists)
            throw new NotFoundException("Category not found");

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            CategoryId = dto.CategoryId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            StockQuantity = product.StockQuantity
        };
    }

    public async Task<ProductDto> UpdateStockAsync(int id, int quantityChange)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");

        var newStock = product.StockQuantity + quantityChange;

        if (newStock < 0)
            throw new BadRequestException("Insufficient stock");

        product.StockQuantity = newStock;

        await _context.SaveChangesAsync();
        
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            StockQuantity = product.StockQuantity
        };
    }


    public async Task<ProductDto> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");

        product.Name = dto.Name;
        product.Price = dto.Price;

        await _context.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            StockQuantity = product.StockQuantity
        };
    }

}
