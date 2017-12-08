using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using Project.Webstore.Services.Messaging.ProductCatalogService.Response;

namespace Project.Webstore.Services.Interfaces
{
    public interface IProductCatalogService
    {
        GetFeaturedProductsResponse GetFeaturedProducts();
        GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
        GetAllCategoriesResponse GetAllCategories();
    }
}
