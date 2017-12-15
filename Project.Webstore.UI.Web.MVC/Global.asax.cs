using Project.Webstore.Infrastructure.Configuration;
using Project.Webstore.Infrastructure.Configuration.Interfaces;
using Project.Webstore.Infrastructure.Email;
using Project.Webstore.Infrastructure.Email.Interfaces;
using Project.Webstore.Infrastructure.Logging;
using Project.Webstore.Infrastructure.Logging.Interfaces;
using Project.Webstore.UI.Web.MVC.App_Start;
using Project.Webstore.UI.Web.MVC.DependencyResolution;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project.Webstore.UI.Web.MVC
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var container = IoC.Initialize();
            Services.AutoMapperBootStrapper.ConfigureAutoMapper();
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory
                (container.GetInstance<IApplicationSettings>());
            LoggerFactory.InitializeLogFactory(container.GetInstance<ILogger>());
            EmailServiceFactory
                .InitializeEmailServiceFactory(container.GetInstance<IEmailService>());

            LoggerFactory.GetLogger().Log($"Application Started in {DateTime.Now}");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}