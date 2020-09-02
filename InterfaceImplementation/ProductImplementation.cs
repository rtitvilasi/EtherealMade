using EtherealMadeFin.Data;
using EtherealMadeFin.Interface;
using EtherealMadeFin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.InterfaceImplementation
{
    public class ProductImplementation : IProduct
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductImplementation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetAll()
        {
            var product = _dbContext.Products
                                    .Include(comment => comment.Comments)
                                    .Include(category => category.ProductCategory);
            return product;
        }

        public Product GetById(int id)
        {
            var product = _dbContext.Products.Where(products => products.ProductId == id)
                                             .Include(comment => comment.Comments)
                                             .Include(category => category.ProductCategory)
                                             .First();
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _dbContext.ProductCategory.Where(products => products.CategoryId == id)
                                             .First()
                                             .Products;
        }

        public async Task AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int Productid)
        {
            var product = GetById(Productid);
            _dbContext.RemoveRange(product.Comments);
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
