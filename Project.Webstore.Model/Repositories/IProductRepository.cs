using Project.Webstore.Infrastructure.Repository.Interfaces;


namespace Project.Webstore.Model.Repositories
{
    public interface IProductRepository : IReadOnlyRepository<Product.Product, int>
    {
    }
}
