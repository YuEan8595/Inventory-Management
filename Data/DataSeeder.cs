using InventoryManagement.Models;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Prevent duplicate seeding
        if (context.Categories.Any())
            return;

        var electronics = new Category
        {
            Name = "Electronics",
            Products =
            {
                new Product { Name = "Laptop", Price = 3500, StockQuantity = 10 },
                new Product { Name = "Mouse", Price = 50, StockQuantity = 100 }
            }
        };

        var groceries = new Category
        {
            Name = "Groceries",
            Products =
            {
                new Product { Name = "Rice", Price = 25, StockQuantity = 200 },
                new Product { Name = "Milk", Price = 5, StockQuantity = 50 }
            }
        };

        context.Categories.AddRange(electronics, groceries);
        context.SaveChanges();
    }
}
