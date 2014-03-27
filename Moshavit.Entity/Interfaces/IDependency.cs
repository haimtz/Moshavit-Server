using System;

namespace Moshavit.Entity
{
    public interface IDependency
    {
        void Register<T, TImp>()
            where T : class
            where TImp : T;

        object Resolver(Type type);
    }
}