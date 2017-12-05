using NHibernate;

namespace Project.Webstore.Repository.SessionStorage.Interfaces
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}
