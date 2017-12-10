using Project.Webstore.Services.Interfaces;
using Project.Webstore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Webstore.UI.Web.MVC.Controllers
{
    public class ProductCatalogBaseController : Controller
    {
        protected readonly IProductCatalogService _productCatalogService;

        public ProductCatalogBaseController(IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            return _productCatalogService.GetAllCategories().Categories;
        }
    }
}