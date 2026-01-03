namespace InventoryManagement.Dtos;

using System.ComponentModel.DataAnnotations;

public class CreateCategoryDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
