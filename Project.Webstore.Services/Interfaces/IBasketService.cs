using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using Project.Webstore.Services.Messaging.ProductCatalogService.Response;

namespace Project.Webstore.Services.Interfaces
{
    public interface IBasketService
    {
        GetBasketResponse GetBasket(GetBasketRequest request);
        CreateBasketResponse CreateBasket(CreateBasketRequest request);
        ModifyBasketResponse ModifyBasket(ModifyBasketRequest request);
        GetAllDispatchOptionsResponse GetAllDispatchOptions();
    }
}
