using Project.Webstore.Model.Basket;
using Project.Webstore.Model.Repositories;
using System;

namespace Project.Webstore.Repository.Repositories
{
    public class BasketRepository : RepositoryBase<Basket, Guid>, IBasketRepository
    {
    }
}
