using Project.Webstore.Infrastructure.UnitOfWork.BaseClasses;
using Project.Webstore.Model.ProductAttributes.Interfaces;

namespace Project.Webstore.Model.ProductAttributes
{
    public class ProductColor : EntityBase<int>, IProductAttribute
    {
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
