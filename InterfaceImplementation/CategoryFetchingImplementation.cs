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
    public class CategoryFetchingImplementation : ICategoryFetching
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryFetchingImplementation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            var productCategorymodel = _dbContext.ProductCategory
                             .Include(productCategory => productCategory.Products);
            return productCategorymodel;
        }
        public ProductCategory GetById(int id)
        {
            var productCategory = _dbContext.ProductCategory.Where(p => p.CategoryId == id)
                .Include(product => product.Products)
                .ThenInclude(comment => comment.Comments)
                .FirstOrDefault();
            return productCategory;
        }
        public async Task Create(ProductCategory Category)
        {
            _dbContext.Add(Category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int categoryid)
        {
            var productCategory = GetById(categoryid);
            _dbContext.RemoveRange(productCategory.Products);
            _dbContext.Remove(productCategory);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateCategoryDescription(int categoryid, string newCategoryDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryTitle(int categoryid, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }
    }
}
