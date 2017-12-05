using Project.Webstore.Infrastructure.Domain.Interfaces;

namespace Project.Webstore.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(IAggregateRoot entity);
        void PersistUpdateOf(IAggregateRoot entity);
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
