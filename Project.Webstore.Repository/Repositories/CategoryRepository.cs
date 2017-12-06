using System.Linq;
using Project.Webstore.Model.ProductAttributes;
using Project.Webstore.Model.Repositories;
using Project.Webstore.Model.Product;
using Project.Webstore.Infrastructure.Domain.BaseClasses;
using System;

namespace Project.Webstore.Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
    {
        public override void Remove(Category entity)
        {            
            var query = SessionFactory.CurrentSession.Query<ProductTitle>();

            var relatedObjects = query
                .Where(e => e.Category == entity && e.Status != EntityStatus.Removed)
                .Count();

            if (relatedObjects > 0)
                throw new ApplicationException("Cannot remove, foreign-key violated.");

            entity.Status = EntityStatus.Removed;
            SessionFactory.CurrentSession.Update(entity);
        }
    }
}
