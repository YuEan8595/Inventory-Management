namespace InventoryManagement.Services;

using InventoryManagement.Dtos;

public interface IProductService
{
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> UpdateAsync(int id, UpdateProductDto dto);
    Task<ProductDto> UpdateStockAsync(int id, int quantityChange);

}
