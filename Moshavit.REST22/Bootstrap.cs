using System.Web.Http;
using System.Web.Http.Dispatcher;
using Moshavit.Castel;
using Moshavit.Entity;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Entity.TableEntity;
using Moshavit.REST.Controllers;
using Moshavit.DataBase;
using Moshavit.REST.Service.Settings;
using Moshavit.REST22.Controllers;
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
            container.Register<BabySitterMessageService, BabySitterMessageService>();
            container.Register<CarPullMessageService, CarPullMessageService>();
            container.Register<IMessageService<BulletinBoardTable, BulletinBoardDto>, MessageService<BulletinBoardTable, BulletinBoardDto>>();
            container.Register<IMessageService<GiveAndTakeTable, GiveAndTakeDto>, MessageService<GiveAndTakeTable, GiveAndTakeDto>>();
            container.Register<ISurveyService, SurveyService>();
            #endregion
            
            #region Repositories
            container.Register<IDataBase<UserTable>, DataBase<UserTable>>();
            container.Register<IDataBase<BabySitterTable>, DataBase<BabySitterTable>>();
            container.Register<IDataBase<CarPullTable>, DataBase<CarPullTable>>();
            container.Register<IDataBase<BulletinBoardTable>, DataBase<BulletinBoardTable>>();
            container.Register<IDataBase<SurveyTable>, DataBase<SurveyTable>>();
            container.Register<IDataBase<GiveAndTakeTable>, DataBase<GiveAndTakeTable>>();
            #endregion

            #region Controllers
            container.Register<LoginController, LoginController>();
            container.Register<RegisterController, RegisterController>();
            container.Register<UserController, UserController>();
            container.Register<BabySitterController, BabySitterController>();
            container.Register<CarpullController, CarpullController>();
            container.Register<BulletinBoardController, BulletinBoardController>();
            container.Register<SurveyController, SurveyController>();
            container.Register<VoteController, VoteController>();
            container.Register<GiveAndTakeController, GiveAndTakeController>();
            container.Register<ForgotPasswordController, ForgotPasswordController>();

            container.Register<SettingsController, SettingsController>();
            #endregion
        }
    }
}