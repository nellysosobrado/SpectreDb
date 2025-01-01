using SpectreTablesToRefactor.Data;
using SpectreTablesToRefactor.Enums;
using SpectreTablesToRefactor.Models;
using Microsoft.EntityFrameworkCore;


namespace SpectreTablesStart.Data
{
    internal class DataInitializer
    {
        public static void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(new Product[]
                {
                    new Product { Name = "Electric Kettle", Price = 299.00m, Category = Category.Kitchen },
                    new Product { Name = "Toaster", Price = 199.00m, Category = Category.Kitchen },
                    new Product { Name = "Microwave Oven", Price = 1299.00m, Category = Category.Kitchen },
                    new Product { Name = "Refrigerator", Price = 7999.00m, Category = Category.Kitchen },
                    new Product { Name = "Washing Machine", Price = 4999.00m, Category = Category.Cleaning },
                    new Product { Name = "Electric Fan", Price = 399.00m, Category = Category.Home },
                    new Product { Name = "Hair Dryer", Price = 249.00m, Category = Category.PersonalCare },
                    new Product { Name = "Vacuum Cleaner", Price = 1799.00m, Category = Category.Cleaning },
                    new Product { Name = "Air Conditioner", Price = 9999.00m, Category = Category.Home },
                    new Product { Name = "Electric Heater", Price = 699.00m, Category = Category.Home }
                });

                dbContext.SaveChanges();  
            }
        }
    }
}
