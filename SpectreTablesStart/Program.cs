using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SpectreTablesToRefactor.Data;
using Microsoft.Extensions.Configuration;
using SpectreTablesStart.Controllers;
using Spectre.Console;
using SpectreTablesStart.Services;
using SpectreTablesToRefactor.Enums;

namespace SpectreTablesToRefactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set up configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            Console.WriteLine($"Connection String från appsettings.json: {connectionString}");

            // Set up Dependency Injection
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ProductService>();  // Register ProductService
            services.AddScoped<ProductController>();  // Register ProductController

            var serviceProvider = services.BuildServiceProvider();

            // Retrieve ProductController from DI
            var productController = serviceProvider.GetRequiredService<ProductController>();

            // Main menu with Spectre Console
            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOptions>()
                        .Title("Select a option:")
                        .UseConverter(option => option.GetDescription()) // Show descriptions instead of enum names
                        .AddChoices(Enum.GetValues<MenuOptions>()));

                switch (option)
                {
                    case MenuOptions.AddProduct:
                        productController.InsertProduct();
                        break;
                    case MenuOptions.ViewAllProducts:
                        productController.GetProducts();
                        break;
                    case MenuOptions.ViewProduct:
                        productController.GetProduct();
                        break;
                    case MenuOptions.UpdateProduct:
                        productController.UpdateProduct();
                        break;
                    case MenuOptions.DeleteProduct:
                        productController.DeleteProduct();
                        break;
                    case MenuOptions.Exit:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
