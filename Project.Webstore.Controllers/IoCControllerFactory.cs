﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Project.Webstore.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        //protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        //{
        //    return ObjectFactory.GetInstance(controllerType) as IController;
        //}
    }
}
