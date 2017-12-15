using Project.Webstore.Infrastructure.Domain.BaseClasses;
using System;
using System.Collections.Generic;

namespace Project.Webstore.Model.Shipping
{
    public class Courier : EntityBase<int>
    {
        private readonly string _name;
        private readonly IEnumerable<ShippingService> _services;

        public Courier(string name, IEnumerable<ShippingService> services)
        {
            _name = name;
            _services = services;
        }

        public string Name => _name;
    
        public IEnumerable<ShippingService> Services => _services;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
