using Project.Webstore.Infrastructure.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Webstore.Model.Basket.Validation
{
    public class BasketItemBusinessRules
    {
        public static readonly BusinessRule BasketRequired =
            new BusinessRule("Basket", "A basket item must be related to a basket.");

        public static readonly BusinessRule ProductRequired =
            new BusinessRule("Product", "A basket item must be related to a product.");

        public static readonly BusinessRule QuantityInvalid =
            new BusinessRule("Quantity", "The quantity of a basket item cannot be less than 1.");
    }
}
