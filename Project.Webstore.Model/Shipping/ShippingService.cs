using Project.Webstore.Infrastructure.Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Webstore.Model.Shipping
{
    public class ShippingService : EntityBase<int>
    {
        private readonly string _code;
        private readonly string _description;
        private readonly Courier _courier;

        public ShippingService(string code, string description, Courier courier)
        {
            _code = code;
            _courier = courier;
            _description = description;
        }

        public string Code => _code;

        public string Description => _description;

        public Courier Courier => _courier;

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
