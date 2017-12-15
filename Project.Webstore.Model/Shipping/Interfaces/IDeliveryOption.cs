namespace Project.Webstore.Model.Shipping.Interfaces
{
    public interface IDeliveryOption
    {
        int Id { get; set; }
        decimal FreeDeliveryThreshold { get; }
        decimal Cost { get; }
        ShippingService ShippingService { get; }
        decimal GetDeliveryChargeFor(decimal total);
    }
}
