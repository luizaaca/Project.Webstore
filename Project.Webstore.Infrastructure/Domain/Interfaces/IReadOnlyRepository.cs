using System.Collections.Generic;
using Project.Webstore.Infrastructure.Querying;

namespace Project.Webstore.Infrastructure.Domain.Interfaces
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
