using Spectre.Console;
using SpectreTablesToRefactor.Models;
using SpectreTablesToRefactor.Enums;
using System;
using System.Collections.Generic;

namespace SpectreTablesToRefactor.UI
{
    public static class DisplayItems
    {
        public static void ShowProductTable(List<Product> products)
        {
            var table = new Table();

            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Price");
            table.AddColumn("Category");

            foreach (var product in products)
            {
                table.AddRow(
                    product.ProductId.ToString(),
                    product.Name,
                    product.Price.ToString("C"),
                    product.Category.GetDescription() 
                );
            }

            AnsiConsole.Render(table);
        }

        public static void ShowProduct(Product product)
        {
            var table = new Table();

            table.AddColumn("Property");
            table.AddColumn("Value");

            table.AddRow("Id", product.ProductId.ToString());
            table.AddRow("Name", product.Name);
            table.AddRow("Price", product.Price.ToString("C"));
            table.AddRow("Category", product.Category.GetDescription()); 

            AnsiConsole.Render(table);
        }
    }
}
