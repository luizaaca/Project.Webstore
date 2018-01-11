using System;
using System.Collections.Generic;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Request
{
    public class ModifyBasketRequest
    {
        public ModifyBasketRequest()
        {
            ItemsToRemove = new List<int>();
            ProductsToAdd = new List<int>();
            ItemsToUpdate = new List<ProductQuantityUpdateRequest>();
        }

        public Guid BasketId { get; set; }
        public int SetShippingServiceIdTo { get; set; }
        public IList<int> ItemsToRemove { get; private set; }
        public IList<int> ProductsToAdd { get; private set; }
        public IList<ProductQuantityUpdateRequest> ItemsToUpdate { get; }
    }
}
