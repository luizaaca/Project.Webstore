using log4net;
using log4net.Config;
using Project.Webstore.Infrastructure.Configuration;
using Project.Webstore.Infrastructure.Logging.Interfaces;

namespace Project.Webstore.Infrastructure.Logging.Classes
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _log;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }
    }
}
