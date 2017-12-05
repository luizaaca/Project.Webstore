using Project.Webstore.Infrastructure.Repository.Interfaces;
using Project.Webstore.Model.Product;

namespace Project.Webstore.Model.Repositories
{
    public interface IProductTitleRepository : IReadOnlyRepository<ProductTitle, int>
    {
    }
}
