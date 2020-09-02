using EtherealMadeFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.Interface
{
    public interface IProduct
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetProductsByCategory(int id);
        Task AddProduct(Product product);
        Task Delete(int Productid);
        
    }
}
