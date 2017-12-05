namespace Project.Webstore.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return $"R${price}";
        }
    }
}
