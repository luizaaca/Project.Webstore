using Project.Webstore.Services.ViewModels;
using System.Collections.Generic;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Response
{
    public class GetAllDispatchOptionsResponse
    {
        public IEnumerable<DeliveryOptionView> DeliveryOptions { get; set; }
    }
}
