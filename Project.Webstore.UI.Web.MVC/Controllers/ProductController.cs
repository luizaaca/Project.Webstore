using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Webstore.Services.Interfaces;
using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using Project.Webstore.Services.Messaging.ProductCatalogService.Response;
using Project.Webstore.Controllers.ViewModels.ProductCatalog;
using Project.Webstore.UI.Web.MVC.ViewModels.JsonDTOs;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.UI.Web.MVC.Controllers
{
    public class ProductController : ProductCatalogBaseController
    {
        public ProductController(IProductCatalogService productCatalogService) : base(productCatalogService)
        {
        }

        public ActionResult GetProductsByCategory(int categoryId)
        {
            var request = GenerateInitialSearchRequestFrom(categoryId);

            var response = _productCatalogService.GetProductsByCategory(request);

            var resultView = GetProductResultViewFrom(response);

            ViewBag.Categories = GetCategories();
            
            return View(resultView);
        }

        public ActionResult Detail(int id)
        {
            var productDetailView = new ProductDetailView();

            var request = new GetProductRequest() { ProductId = id };

            var response = _productCatalogService.GetProduct(request);

            productDetailView.Product = response.Product;

            ViewBag.Categories = GetCategories();

            return View(productDetailView);
        }

        [HttpPost]
        public JsonResult GetProducts(JsonProductSearchRequest jsonRequest)
        {
            var request = GenerateProductSearchRequestFrom(jsonRequest);

            var response = _productCatalogService.GetProductsByCategory(request);

            var result = GetProductResultViewFrom(response);

            return Json(result);
        }

        private static GetProductsByCategoryRequest GenerateProductSearchRequestFrom(JsonProductSearchRequest jsonRequest)
        {
            var request = new GetProductsByCategoryRequest();

            request.NumberOfResultsPerPage = 6;
            request.CategoryId = jsonRequest.CategoryId;
            request.PageIndex = jsonRequest.PageIndex;
            request.SortBy = jsonRequest.SortBy;

            foreach (var item in jsonRequest.RefinementGroups)
            {
                switch ((RefinementGroupings)item.GroupId)
                {
                    case RefinementGroupings.brand:
                        request.BrandIds = item.SelectedRefinements;
                        break;
                    case RefinementGroupings.color:
                        request.ColorIds = item.SelectedRefinements;
                        break;
                    case RefinementGroupings.size:
                        request.SizeIds = item.SelectedRefinements;
                        break;
                    default:
                        break;
                }

            }

            return request;
        }

        private ProductSearchResultView GetProductResultViewFrom(GetProductsByCategoryResponse response)
        {
            var result = new ProductSearchResultView();

            result.CurrentPage = response.CurrentPage;
            result.NumberOfTitlesFound = response.NumberOfTitlesFound;
            result.Products = response.Products;
            result.RefinementGroups = response.RefinementGroups;
            result.SelectedCategory = response.SelectedCategory;
            result.SelectedCategoryName = response.SelectedCategoryName;
            result.TotalNumberOfPages = response.TotalNumberOfPages;

            return result;
        }

        private static GetProductsByCategoryRequest GenerateInitialSearchRequestFrom(int categoryId)
        {
            var request = new GetProductsByCategoryRequest();

            request.NumberOfResultsPerPage = 6;
            request.CategoryId = categoryId;
            request.PageIndex = 1;
            request.SortBy = ProductsSortBy.PriceHighToLow;

            return request;
        }
    }
}