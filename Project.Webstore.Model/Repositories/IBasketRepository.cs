using System;
using Project.Webstore.Infrastructure.Repository.Interfaces;

namespace Project.Webstore.Model.Repositories
{
    public interface IBasketRepository : IRepository<Basket.Basket, Guid>
    {
    }
}
