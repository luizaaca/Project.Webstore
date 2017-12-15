using Project.Webstore.Infrastructure.Domain.BaseClasses;
using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Model.Shipping.Interfaces;
using System;

namespace Project.Webstore.Model.Shipping
{
    public class DeliveryOption : EntityBase<int>, IAggregateRoot, IDeliveryOption
    {
        private readonly decimal _freeDeliveryThreshold;
        private readonly decimal _cost;
        private readonly ShippingService _shippingService;

        public DeliveryOption(decimal freeDeliveryThreshold, decimal cost, ShippingService shippingService)
        {
            _freeDeliveryThreshold = freeDeliveryThreshold;
            _cost = cost;
            _shippingService = shippingService;
        }        

        public decimal FreeDeliveryThreshold => _freeDeliveryThreshold;

        public decimal Cost => _cost;

        public ShippingService ShippingService => _shippingService;

        public decimal GetDeliveryChargeFor(decimal total)
        {
            if (total > FreeDeliveryThreshold)
                return 0;

            return Cost;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
