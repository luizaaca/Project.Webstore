using Project.Webstore.Model.ProductAttributes.Interfaces;
using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Infrastructure.Domain.BaseClasses;

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
