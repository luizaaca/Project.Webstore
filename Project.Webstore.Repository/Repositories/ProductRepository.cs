using Project.Webstore.Model.Product;
using Project.Webstore.Model.Repositories;
using Project.Webstore.Infrastructure.Domain.BaseClasses;

namespace Project.Webstore.Repository.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public override void Remove(Product entity)
        {
            entity.Status = EntityStatus.Removed;
            SessionFactory.CurrentSession.Update(entity);
        }
    }
}
