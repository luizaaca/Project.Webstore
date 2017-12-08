using System.Collections.Generic;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Response
{
    public class GetFeaturedProductsResponse
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
