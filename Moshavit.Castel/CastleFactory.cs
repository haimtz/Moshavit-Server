using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Moshavit.Entity;

namespace Moshavit.Castel
{
    public class CastleFactory : IDependency
    {
        private readonly IWindsorContainer _container;

        public CastleFactory()
        {
            _container = new WindsorContainer();
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
        
    }
}
