using Project.Webstore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Webstore.Services.Messaging.ProductCatalogService.Request;
using Project.Webstore.Services.Messaging.ProductCatalogService.Response;
using Project.Webstore.Model.Repositories;
using Project.Webstore.Model.Basket;
using Project.Webstore.Model.Shipping.Interfaces;
using Project.Webstore.Services.ViewModels;
using Project.Webstore.Services.Mapping;
using Project.Webstore.Model.Product;
using Project.Webstore.Services.Implementations.Utils;

namespace Project.Webstore.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;

        public BasketService(IBasketRepository basketRepository, IProductRepository productRepository, IDeliveryOptionRepository deliveryOptionRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
        }

        public CreateBasketResponse CreateBasket(CreateBasketRequest request)
        {
            var response = new CreateBasketResponse();

            var basket = new Basket();

            basket.DeliveryOption = GetCheapestDeliveryOption();

            AddProductsToBasket(request.ProductsToAdd, basket);

            ThrowExceptionIfBasketIsInvalid(basket);

            _basketRepository.Save(basket);
            _basketRepository.Commit();

            response.Basket = basket.ToBasketView();

            return response;
        }

        public GetAllDispatchOptionsResponse GetAllDispatchOptions()
        {
            var response = new GetAllDispatchOptionsResponse();

            response.DeliveryOptions = _deliveryOptionRepository
                .FindAll()
                .OrderBy(o => o.Cost)
                .ToDeliveryOptionViews();

            return response;
        }

        public GetBasketResponse GetBasket(GetBasketRequest request)
        {
            var response = new GetBasketResponse();

            var basket = _basketRepository.FindBy(request.BasketId);

            BasketView basketView;

            if (basket == null)
                throw new BasketDoesNotExistException();

            basketView = basket.ToBasketView();

            //if (basket != null)
            //    basketView = basket.ToBasketView();
            //else
            //    basketView = new BasketView();

            response.Basket = basketView;

            return response;
        }

        public ModifyBasketResponse ModifyBasket(ModifyBasketRequest request)
        {
            var response = new ModifyBasketResponse();
            var basket = _basketRepository.FindBy(request.BasketId);

            if (basket == null)
                throw new BasketDoesNotExistException();

            AddProductsToBasket(request.ProductsToAdd, basket);

            UpdateLineQuantity(request.ItemsToUpdate, basket);

            RemoveItemsFromBasket(request.ItemsToRemove, basket);

            if (request.SetShippingServiceIdTo != 0)
            {
                var deliveryOption = _deliveryOptionRepository
                    .FindBy(request.SetShippingServiceIdTo);

                basket.DeliveryOption = deliveryOption;
            }

            ThrowExceptionIfBasketIsInvalid(basket);

            _basketRepository.Save(basket);
            _basketRepository.Commit();

            response.Basket = basket.ToBasketView();

            return response;
        }

        private IDeliveryOption GetCheapestDeliveryOption() =>
            _deliveryOptionRepository.FindAll().OrderBy(o => o.Cost).FirstOrDefault();
        
        private void AddProductsToBasket(IList<int> productsToAdd, Basket basket)
        {
            foreach (var productId in productsToAdd)
                basket.Add(_productRepository.FindBy(productId));
        }

        private void RemoveItemsFromBasket(IList<int> itemsToRemove, Basket basket)
        {
            foreach (var productId in itemsToRemove)
                basket.Remove(_productRepository.FindBy(productId));
        }

        private void UpdateLineQuantity(IList<ProductQuantityUpdateRequest> itemsToUpdate, Basket basket)
        {
            foreach (var item in itemsToUpdate)
            {
                var product = _productRepository.FindBy(item.ProductId);
                basket.ChangeQuantityOf(product, item.NewQuantity);
            }
        }

        private void ThrowExceptionIfBasketIsInvalid(Basket basket)
        {
            var brokenRules = basket.GetBrokenRules();

            if (brokenRules.Count() > 0)
            {
                StringBuilder brokenRulesDescription = new StringBuilder();

                brokenRulesDescription.AppendLine("There were problems saving the Basket:");

                foreach (var item in brokenRules)
                {
                    brokenRulesDescription.AppendLine(item.Rule);
                }

                throw new ApplicationException(brokenRulesDescription.ToString());
            }
        }
    }
}
