using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EtherealMadeFin.Models;
using Microsoft.AspNetCore.Authorization;
using EtherealMadeFin.Interface;

namespace EtherealMadeFin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryFetching _Icategory;
        private readonly IProduct _Iproduct;
        private readonly IComment _Icomment;

        public HomeController(ICategoryFetching Icategory, IProduct Iproduct, IComment Icomment)
        {
            _Icategory = Icategory;
            _Iproduct = Iproduct;
            _Icomment = Icomment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult OurFacts()
        {
            return View();
        }
        public IActionResult Shop()
        {
            var categories = _Icategory.GetAll().Select(category => new ProductCategory
            {
                CategoryId = category.CategoryId,
                CategoryTitle = category.CategoryTitle,
                CategoryDescription = category.CategoryDescription,
                CategoryImageUrl = category.CategoryImageUrl,
                CategoryExtraDescription = category.CategoryExtraDescription
            });
            var model = new ProductCategoryListingModel
            {
                Categories = categories
            };
            return View(model);
        }
        public IActionResult ProductsByCategory(int id)
        {
            var products = new List<Product>();
            products = _Iproduct.GetProductsByCategory(id).ToList();
            var model = new ProductListingModel
            {
                Products = products
            };
            return View(model);
        }
        public IActionResult Product(int id)
        {
            var product = _Iproduct.GetById(id);
            return View(product);
        }

        [Authorize]
        public IActionResult AddCategory()
        {
            var model = new ProductCategory();
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProductCategory(ProductCategory productCategory)
        {
            await _Icategory.Create(productCategory);
            return RedirectToAction("Shop", "Home");
        }
        [Authorize]
        public IActionResult AddProduct(int id)
        {
            var category = _Icategory.GetById(id);
            var model = new Product
            {
                Productcategory = category 
            };
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProductModule(Product product)
        {
            await _Iproduct.AddProduct(product);
            return RedirectToAction("Product", "Home", new { id = product.ProductId });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
