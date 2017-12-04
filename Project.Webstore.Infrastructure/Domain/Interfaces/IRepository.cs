namespace Project.Webstore.Infrastructure.Domain.Interfaces
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        void Add(T entity);
        void Remove(T entity);
        void Save(T entity);
    }
}
