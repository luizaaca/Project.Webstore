using Project.Webstore.Infrastructure.Domain.Interfaces;

namespace Project.Webstore.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void Commit();
    }
}
