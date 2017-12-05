using System.Web;
using NHibernate;
using System.Collections;
using Project.Webstore.Repository.SessionStorage.Interfaces;

namespace Project.Webstore.Repository.SessionStorage.Classes
{
    public class HttpSessionStorageContainer : ISessionStorageContainer
    {
        private static string _sessionKey = "NHSession";
        private static IDictionary HttpCurrentItems { get => HttpContext.Current.Items; }

        public ISession GetCurrentSession()
        {
            ISession nhSession = null;

            if (HttpCurrentItems.Contains(_sessionKey))
                nhSession = (ISession)HttpCurrentItems[_sessionKey];

            return nhSession;
        }

        public void Store(ISession session)
        {
            if (HttpCurrentItems.Contains(_sessionKey))
                HttpCurrentItems[_sessionKey] = session;
            else
                HttpCurrentItems.Add(_sessionKey, session);
        }
    }
}
