using Project.Webstore.Repository.SessionStorage.Classes;
using Project.Webstore.Repository.SessionStorage.Interfaces;
using System.Web;

namespace Project.Webstore.Repository.SessionStorage
{
    public class SessionStorageFactory
    {
        private static ISessionStorageContainer _nhSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if(_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                else
                    _nhSessionStorageContainer = new HttpSessionStorageContainer();
            }

            return _nhSessionStorageContainer;
        }
    }
}
