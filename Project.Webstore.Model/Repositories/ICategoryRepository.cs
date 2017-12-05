using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Model.ProductAttributes;

namespace Project.Webstore.Model.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
