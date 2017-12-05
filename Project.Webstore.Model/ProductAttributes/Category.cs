using Project.Webstore.Infrastructure.UnitOfWork.BaseClasses;
using Project.Webstore.Model.ProductAttributes.Interfaces;
using Project.Webstore.Infrastructure.Domain.Interfaces;

namespace Project.Webstore.Model.ProductAttributes
{
    public class Category : EntityBase<int>, IAggregateRoot, IProductAttribute
    {
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
