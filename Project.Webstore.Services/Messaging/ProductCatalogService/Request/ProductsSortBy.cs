using System.ComponentModel;

namespace Project.Webstore.Services.Messaging.ProductCatalogService.Request
{
    public enum ProductsSortBy
    {
        [Description("Price - High to Low")]
        PriceHighToLow = 1,
        [Description("Price - Low to High")]
        PriceLowToHigh = 2
    }
}
