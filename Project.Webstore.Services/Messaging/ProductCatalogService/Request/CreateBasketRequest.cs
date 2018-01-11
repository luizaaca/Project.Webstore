using System.Collections.Generic;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Request
{
    public class CreateBasketRequest
    {
        public CreateBasketRequest()
        {
            ProductsToAdd = new List<int>();
        }
        public IList<int> ProductsToAdd { get; set; }
    }
}
