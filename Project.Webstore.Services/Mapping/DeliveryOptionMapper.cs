using AutoMapper;
using Project.Webstore.Model.Shipping;
using Project.Webstore.Services.ViewModels;
using System.Collections.Generic;

namespace Project.Webstore.Services.Mapping
{
    public static class DeliveryOptionMapper
    {
        public static IEnumerable<DeliveryOptionView> ToDeliveryOptionViews(this IEnumerable<DeliveryOption> deliveryOptions) =>
            Mapper.Map<IEnumerable<DeliveryOption>, IEnumerable<DeliveryOptionView>>(deliveryOptions);
    }
}
