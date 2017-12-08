using System.Collections.Generic;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Response
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
