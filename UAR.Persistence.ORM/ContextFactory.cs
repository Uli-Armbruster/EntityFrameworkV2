using System.Data.Entity;
using System.Linq;

using Castle.Windsor;

using UAR.Persistence.Contracts;

namespace UAR.Persistence.ORM
{
    internal class ContextFactory : IContextFactory
    {
        readonly IWindsorContainer _container;

        public ContextFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IDbContext Create<TEntity>()
        {
            var contextName = typeof(TEntity).Namespace.Split('.').Last() + "Context";
            return new WrappedContext(_container.Resolve<DbContext>(contextName));
        }
    }
}