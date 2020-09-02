using EtherealMadeFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.Interface
{
    public interface ICategoryFetching
    {
        ProductCategory GetById(int id);
        IEnumerable<ProductCategory> GetAll();
        Task Create(ProductCategory Category);
        Task Delete(int categoryid);
        Task UpdateCategoryTitle(int categoryid, string newCategoryTitle);
        Task UpdateCategoryDescription(int categoryid, string newCategoryDescription);
    }
}
