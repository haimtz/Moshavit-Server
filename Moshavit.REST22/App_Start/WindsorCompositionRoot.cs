using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Moshavit.Castel;
using Moshavit.Entity;

namespace Moshavit.REST.Controllers
{
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IDependency _container;

        public WindsorCompositionRoot(IDependency container)
        {
            _container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)_container.Resolver(controllerType);

            return controller;
        }
    }
}