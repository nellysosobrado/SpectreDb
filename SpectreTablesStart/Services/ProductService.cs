using SpectreTablesToRefactor.Data;
using SpectreTablesToRefactor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpectreTablesStart.Services
{
    internal class ProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        internal List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        internal Product GetProductById(int id)
        {
            return _dbContext.Products.SingleOrDefault(x => x.ProductId == id);
        }

        internal void UpdateProduct(Product product)
        {
            var productToUpdate = _dbContext.Products.SingleOrDefault(x => x.ProductId == product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Category = product.Category;
                _dbContext.SaveChanges();
            }
        }

        internal void DeleteProduct(Product product)
        {
            var productToDelete = _dbContext.Products.SingleOrDefault(x => x.ProductId == product.ProductId);

            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
