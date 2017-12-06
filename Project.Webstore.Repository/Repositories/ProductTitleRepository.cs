using Project.Webstore.Infrastructure.Domain.BaseClasses;
using System;
using System.Linq;
using Project.Webstore.Model.Product;
using Project.Webstore.Model.Repositories;

namespace Project.Webstore.Repository.Repositories
{
    public class ProductTitleRepository : RepositoryBase<ProductTitle, int>, IProductTitleRepository
    {
        public override void Remove(ProductTitle entity)
        {
            var query = SessionFactory.CurrentSession.Query<Product>();

            var relatedObjects = query
                .Where(e => e.Title == entity && e.Status != EntityStatus.Removed)
                .Count();

            if (relatedObjects > 0)
                throw new ApplicationException("Cannot remove, foreign-key violated.");

            entity.Status = EntityStatus.Removed;
            SessionFactory.CurrentSession.Update(entity);
        }
    }
}
