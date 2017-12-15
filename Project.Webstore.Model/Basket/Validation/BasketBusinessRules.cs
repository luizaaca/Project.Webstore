using Project.Webstore.Infrastructure.Domain.Validation;

namespace Project.Webstore.Model.Basket.Validation
{
    public class BasketBusinessRules
    {
        public static readonly BusinessRule DeliveryOptionRequired =
            new BusinessRule("DeliveryOption", "A basket must have a valid delivery option");
        public static readonly BusinessRule ItemInvalid =
            new BusinessRule("Item", "A basket cannot have any invalid item.");
    }
}
