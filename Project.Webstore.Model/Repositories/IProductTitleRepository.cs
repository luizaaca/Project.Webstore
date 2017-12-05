using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Model.Product;

namespace Project.Webstore.Model.Repositories
{
    public interface IProductTitleRepository : IReadOnlyRepository<ProductTitle, int>
    {
    }
}
