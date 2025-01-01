using Spectre.Console;
using SpectreTablesToRefactor.Models;
using SpectreTablesToRefactor.UI;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SpectreTablesStart.Services;
using SpectreTablesToRefactor.Enums;

namespace SpectreTablesStart.Controllers
{
    internal class ProductController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        internal void InsertProduct()
        {
            var product = new Product
            {
                Name = AnsiConsole.Ask<string>("Product name:"),
                Price = AnsiConsole.Ask<decimal>("Product price:")
            };

            var categoryDescriptions = Enum.GetValues<Category>()
                .Cast<Category>()
                .ToDictionary(
                    category => category,
                    category => category.GetDescription());

            var selectedCategoryDescription = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose a category:")
                    .AddChoices(categoryDescriptions.Values)
            );

            product.Category = categoryDescriptions
                .First(kvp => kvp.Value == selectedCategoryDescription).Key;

            _productService.AddProduct(product);  
        }

        internal void GetProducts()
        {
            var products = _productService.GetProducts();  
            DisplayItems.ShowProductTable(products);
        }

        internal void GetProduct()
        {
            var product = GetProductOptionInput();
            DisplayItems.ShowProduct(product);
        }

        internal void UpdateProduct()
        {
            var product = GetProductOptionInput();

            if (AnsiConsole.Confirm("Update name?"))
                product.Name = AnsiConsole.Ask<string>("Product new name:");

            if (AnsiConsole.Confirm("Update price?"))
                product.Price = AnsiConsole.Ask<decimal>("Product new price:");

            _productService.UpdateProduct(product);  
        }

        internal void DeleteProduct()
        {
            var product = GetProductOptionInput();
            _productService.DeleteProduct(product);  
        }

        internal Product GetProductOptionInput()
        {
            var products = _productService.GetProducts();  

            var productsArrayForDisplay = products.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose product")
                .AddChoices(productsArrayForDisplay));

            var id = products.Single(x => x.Name == option).ProductId;
            var product = _productService.GetProductById(id);

            return product;
        }
    }
}

