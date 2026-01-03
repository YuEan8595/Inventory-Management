namespace InventoryManagement.Services;

using InventoryManagement.Dtos;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
}
