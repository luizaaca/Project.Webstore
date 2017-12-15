using Project.Webstore.Infrastructure.Domain.BaseClasses;
using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Model.Basket.Factories;
using Project.Webstore.Model.Basket.Validation;
using Project.Webstore.Model.Shipping;
using Project.Webstore.Model.Shipping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Webstore.Model.Basket
{
    public class Basket : EntityBase<Guid>, IAggregateRoot
    {
        private IList<BasketItem> _items;
        private IDeliveryOption _deliveryOption;

        public Basket()
        {
            _items = new List<BasketItem>();
            _deliveryOption = new NullDeliveryOption();
        }

        public IDeliveryOption DeliveryOption
        {
            get => _deliveryOption;
            set => _deliveryOption = value;
        }

        public IList<BasketItem> Items => _items;

        public int NumberOfItems => Items.Sum(i => i.Quantity);

        public decimal ItemsTotal => Items.Sum(i => i.LineTotal);

        public decimal DeliveryCost => DeliveryOption.GetDeliveryChargeFor(ItemsTotal);

        public decimal BasketTotal => ItemsTotal + DeliveryCost;

        private BasketItem GetItemFor(Product.Product product) =>
            Items.Where(i => i.Contains(product)).FirstOrDefault();

        private bool BasketAlreadyContains(Product.Product product) =>
            Items.Any(i => i.Contains(product));

        public void Add(Product.Product product)
        {
            if (BasketAlreadyContains(product))
                GetItemFor(product).IncreaseItemBy(1);
            else
                Items.Add(BasketItemFactory.CreateItemFor(product, this));
        }

        public void Remove(Product.Product product)
        {
            if (BasketAlreadyContains(product))
                Items.Remove(GetItemFor(product));
        }

        public void ChangeQuantityOf(Product.Product product, int quantity)
        {
            if (BasketAlreadyContains(product))
                GetItemFor(product).ChangeItemQuantityTo(quantity);
        }

        protected override void Validate()
        {
            if (DeliveryOption == null)
                base.AddBrokenRule(BasketBusinessRules.DeliveryOptionRequired);

            foreach (var item in Items)
            {
                if (item.GetBrokenRules().Count() > 0)
                    base.AddBrokenRule(BasketBusinessRules.ItemInvalid);
            }
        }
    }
}
