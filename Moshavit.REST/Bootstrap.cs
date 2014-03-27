using System.Web.Http;
using System.Web.Http.Dispatcher;
using Moshavit.Castel;
using Moshavit.Entity;
using Moshavit.REST.Controllers;
using Moshavit.DataBase;
using Moshavit.REST.Service.Settings;
using Moshavit.Service;

namespace Moshavit.REST
{
    public class Bootstrap
    {
        public static void Initialized()
        {
            var container = new CastleFactory();

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));

            Register(container);
        }

        public static void Register(IDependency container)
        {
            container.Register<IHttpControllerActivator, WindsorCompositionRoot>();

            container.Register<IConnection, ConnectionConfig>();

            container.Register<IRepository<User>, Repository<User>>();

            container.Register<UserService, UserService>();

            container.Register<LoginController, LoginController>();

            container.Register<RegisterController, RegisterController>();
        }
    }
}