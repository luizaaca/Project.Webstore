using NHibernate;
using NHibernate.Cfg;
using Project.Webstore.Repository.SessionStorage;
using Project.Webstore.Repository.SessionStorage.Interfaces;

namespace Project.Webstore.Repository
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static void Init()
        {
            Configuration config = new Configuration();
            config.AddAssembly("Project.Webstore.Repository");

            log4net.Config.XmlConfigurator.Configure();

            config.Configure();

            _sessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if(currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}
