// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Project.Webstore.UI.Web.MVC.DependencyResolution {
    using Project.Webstore.Infrastructure.Configuration.Classes;
    using Project.Webstore.Infrastructure.Configuration.Interfaces;
    using Project.Webstore.Infrastructure.Email.Classes;
    using Project.Webstore.Infrastructure.Email.Interfaces;
    using Project.Webstore.Infrastructure.Logging.Classes;
    using Project.Webstore.Infrastructure.Logging.Interfaces;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.Assembly("Project.Webstore.Infrastructure");
                    scan.Assembly("Project.Webstore.Repository");
                    scan.Assembly("Project.Webstore.Model");
                    scan.Assembly("Project.Webstore.Services");
                    //scan.Assembly("Project.Webstore.ServiceCache");
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
            For<ILogger>().Use<Log4NetAdapter>();
            For<IEmailService>().Use<SMTPService>();
        }

        #endregion
    }
}