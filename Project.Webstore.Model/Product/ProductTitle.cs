using System;
using System.Collections.Generic;
using Project.Webstore.Infrastructure.Domain.BaseClasses;
using Project.Webstore.Model.ProductAttributes;
using Project.Webstore.Infrastructure.Domain.Interfaces;

namespace Project.Webstore.Model.Product
{
    public class ProductTitle : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; internal set; }
        public ProductColor Color { get; internal set; }
        public Category.Category Category { get; internal set; }
        public IEnumerable<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
