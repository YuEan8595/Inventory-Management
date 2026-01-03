namespace InventoryManagement.Dtos;

using System.ComponentModel.DataAnnotations;

public class UpdateProductDto
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
}
