using global::NHibernate;
using System.Collections;
using System.Threading;
using System;
using Project.Webstore.Repository.SessionStorage.Interfaces;

namespace Project.Webstore.Repository.SessionStorage.Classes
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static Hashtable _nhSessions = new Hashtable();
        private static string ThreadName { get => Thread.CurrentThread.Name; }

        public ISession GetCurrentSession()
        {
            ISession nhSession = null;

            if (_nhSessions.Contains(ThreadName))
                nhSession = (ISession)_nhSessions[ThreadName];

            return nhSession;
        }

        public void Store(ISession session)
        {
            if (_nhSessions.Contains(ThreadName))
                _nhSessions[ThreadName] = session;
            else
                _nhSessions.Add(ThreadName, session);
        }

    }
}
