using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Webstore.Services.Interfaces;
using Project.Webstore.Controllers.ViewModels.ProductCatalog;

namespace Project.Webstore.UI.Web.MVC.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        public HomeController(IProductCatalogService productCatalogService) : base(productCatalogService)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();

            homePageView.Products = _productCatalogService.GetFeaturedProducts().Products;

            ViewBag.Categories = GetCategories();

            return View(homePageView);
        }
    }
}