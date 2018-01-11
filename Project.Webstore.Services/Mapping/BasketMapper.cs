using AutoMapper;
using Project.Webstore.Model.Basket;
using Project.Webstore.Services.ViewModels;

namespace Project.Webstore.Services.Mapping
{
    public static class BasketMapper
    {
        public static BasketView ToBasketView(this Basket basket) 
            => Mapper.Map<Basket, BasketView>(basket);
    }
}
