using System.Collections.Generic;
using Project.Webstore.Infrastructure.Querying;
using Project.Webstore.Infrastructure.Domain.Interfaces;

namespace Project.Webstore.Infrastructure.Repository.Interfaces
{
    public interface IReadOnlyRepository<T, TEntityKey> where T : IAggregateRoot
    {
        T FindBy(TEntityKey id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query<T> query);
        IEnumerable<T> FindBy(Query<T> query, int index, int count);
    }
}
