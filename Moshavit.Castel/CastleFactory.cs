using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Moshavit.Entity;
using Moshavit.Entity.Interfaces;
using Moshavit.MailService;
using Moshavit.Mapper;
using Moshavit.DataBase;
using Moshavit.Service;

namespace Moshavit.Castel
{
    public class CastleFactory : IDependency
    {
        private readonly IWindsorContainer _container;

        public CastleFactory()
        {
            _container = new WindsorContainer();
            RegisterInfrastructure();
        }

        public void Register<T, TImp>() where T : class where TImp : T
        {
            var component = Component.For<T>();
            component.ImplementedBy<TImp>();
            component.LifestyleTransient();

            _container.Register(component);
        }

        public object Resolver(Type type)
        {
            return _container.Resolve(type);
        }

        public T Resolver<T>()
        {
            return _container.Resolve<T>();
        }

        private void RegisterInfrastructure()
        {
            _container.Register(Component.For<IMapperType>().ImplementedBy<TypeMapper>());
            _container.Register(Component.For<IMapperRepository>().ImplementedBy<MapperRepository>());
            _container.Register(Component.For<IDataBase<VotingLIstTable>>().ImplementedBy<DataBase<VotingLIstTable>>());
            _container.Register(Component.For<IDataBase<EmailTemplate>>().ImplementedBy<DataBase<EmailTemplate>>());
            _container.Register(Component.For<IVoteService>().ImplementedBy<VoteService>());
            _container.Register(Component.For<ISendMail>().ImplementedBy<SendMail>());
            _container.Register(Component.For<IForgotPasswordService>().ImplementedBy<ForgotPasswordService>());
            _container.Register(Component.For<IForgotPasswordMailService>().ImplementedBy<ForgotPasswordMailService>());
            _container.Register(Component.For<ITemplateService>().ImplementedBy<TemplateService>());
            _container.Register(Component.For<IWelcomeMailService>().ImplementedBy<WelcomeMailService>());
        }

    }
}
