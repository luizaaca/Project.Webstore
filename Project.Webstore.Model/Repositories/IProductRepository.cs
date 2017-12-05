using Project.Webstore.Infrastructure.Domain.Interfaces;


namespace Project.Webstore.Model.Repositories
{
    public interface IProductRepository : IReadOnlyRepository<Product.Product, int>
    {
    }
}
