using System.Web.Http;
using System.Web.Http.Dispatcher;
using Moshavit.Castel;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Entity.TableEntity;
using Moshavit.Mapper;
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
            #region Settings
            container.Register<IHttpControllerActivator, WindsorCompositionRoot>();
            container.Register<IConnection, ConnectionConfig>();
            #endregion

            #region Services
            container.Register<IUserService, UserService>();
            container.Register<IMessageService, MessageService>();
            #endregion
            
            #region Repositories
            container.Register<IDataBase<UserTable>, DataBase<UserTable>>();
            container.Register<IDataBase<MessageTable>, DataBase<MessageTable>>();
            #endregion

            #region Controllers
            container.Register<LoginController, LoginController>();
            container.Register<RegisterController, RegisterController>();
            container.Register<MessageController, MessageController>();
            #endregion
        }
    }
}