using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Infrastructure.UnitOfWork.BaseClasses;
using Project.Webstore.Model.ProductAttributes;

namespace Project.Webstore.Model.Product
{
    public class Product : EntityBase<int>, IAggregateRoot
    {
        public ProductSize Size { get; set; }

        public ProductTitle Title { get; set; }

        public string Name { get => Title.Name; }

        public decimal Price { get => Title.Price; }

        public Brand Brand { get => Title.Brand; }

        public ProductColor Color { get => Title.Color; }

        public Category Category { get => Title.Category; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
