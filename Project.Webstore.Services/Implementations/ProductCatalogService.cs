using Project.Webstore.Services.Interfaces;
using System;
using System.Collections.Generic;
using Project.Webstore.Services.Mapping;
using System.Text;
using System.Threading.Tasks;
using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using Project.Webstore.Services.Messaging.ProductCatalogService.Response;
using Project.Webstore.Model.Repositories;
using Project.Webstore.Model.Product;
using Project.Webstore.Infrastructure.Querying;

namespace Project.Webstore.Services.Implementations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCatalogService(IProductTitleRepository productTitleRepository,
            IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productTitleRepository = productTitleRepository;
        }        

        public GetAllCategoriesResponse GetAllCategories()
        {
            var response = new GetAllCategoriesResponse();

            response.Categories = _categoryRepository.FindAll().ToCategoryViews();

            return response;
        }

        public GetFeaturedProductsResponse GetFeaturedProducts()
        {
            var response = new GetFeaturedProductsResponse();

            var query = new Query<ProductTitle>(pt => true)
                .OrderBy(new OrderByClause<ProductTitle>(pt => pt.Price, true));

            response.Products = _productTitleRepository.FindBy(query, 0, 6).ToProductSummaryView();

            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var response = new GetProductResponse();

            response.Product = _productTitleRepository.FindBy(request.ProductId).ToProductView();

            return response;
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            var query = ProductSearchRequestQueryGenerator.CreateQueryFor(request);

            var products = _productRepository.FindBy(query);

            var response = products.CreateResultFrom(request);

            response.SelectedCategoryName = _categoryRepository.FindBy(request.CategoryId).Name;

            return response;
        }
    }
}
