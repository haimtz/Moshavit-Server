using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Moshavit.Entity;
using Moshavit.Mapper;

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

        private void RegisterInfrastructure()
        {
            _container.Register(Component.For<IMapperType>().ImplementedBy<TypeMapper>());
            _container.Register(Component.For<IMapperRepository>().ImplementedBy<MapperRepository>());
        }

    }
}
