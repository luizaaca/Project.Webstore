using Project.Webstore.Model.Shipping.Interfaces;
using System;

namespace Project.Webstore.Model.Shipping
{
    public class NullDeliveryOption : IDeliveryOption
    {
        public int Id { get; set; }

        public decimal FreeDeliveryThreshold => 0;

        public decimal Cost => 0;

        public ShippingService ShippingService => throw new NotImplementedException();

        public decimal GetDeliveryChargeFor(decimal total) => 0;
    }
}
