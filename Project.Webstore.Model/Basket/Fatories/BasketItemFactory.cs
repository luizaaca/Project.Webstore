namespace Project.Webstore.Model.Basket.Factories
{
    public class BasketItemFactory
    {
        public static BasketItem CreateItemFor(Product.Product product, Basket basket) => new BasketItem(product, basket, 1);
    }
}
