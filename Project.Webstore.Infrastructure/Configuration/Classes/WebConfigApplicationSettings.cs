using Project.Webstore.Infrastructure.Configuration.Interfaces;
using System.Configuration;

namespace Project.Webstore.Infrastructure.Configuration.Classes
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get => ConfigurationManager.AppSettings["LoggerName"];
        }
    }
}
