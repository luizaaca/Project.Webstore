using Project.Webstore.Infrastructure.Domain.BaseClasses;
using Project.Webstore.Model.Basket.Validation;

namespace Project.Webstore.Model.Basket
{
    public class BasketItem : EntityBase<int>
    {
        private int _quantity;
        private Product.Product _product;
        private Basket _basket;

        public BasketItem(Product.Product product, Basket basket, int quantity)
        {
            _product = product;
            _basket = basket;
            _quantity = quantity;
        }

        public int Quantity => _quantity;

        public Product.Product Product => _product;

        public Basket Basket => _basket;

        public decimal LineTotal => Product.Price * Quantity;

        public bool Contains(Product.Product product) => product == Product;

        public void IncreaseItemBy(int quantity)
        {
            _quantity += quantity;
        }

        public void ChangeItemQuantityTo(int quantity)
        {
            _quantity = quantity;
        }

        protected override void Validate()
        {
            if (Quantity < 1)
                base.AddBrokenRule(BasketItemBusinessRules.QuantityInvalid);
            if (Product == null)
                base.AddBrokenRule(BasketItemBusinessRules.ProductRequired);
            if (Basket == null)
                base.AddBrokenRule(BasketItemBusinessRules.BasketRequired);
        }
    }
}
