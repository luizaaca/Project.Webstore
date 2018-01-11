namespace Project.Webstore.Services.Messaging.ProductCatalogService.Request
{
    public class ProductQuantityUpdateRequest
    {
        public int ProductId { get; set; }
        public int NewQuantity { get; set; }
    }
}
