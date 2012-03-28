using System.Collections.Generic;
using System.Linq;

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using UAR.Persistence.Contracts;

namespace UAR.Persistence.ORM
{
    public class Installer : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
        /// </summary>
        /// <param name="container">The container.</param><param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Components().ToArray());

            if (!container.Kernel.GetFacilities().Any(x => x is TypedFactoryFacility))
            {
                container.AddFacility<TypedFactoryFacility>();
            }
        }

        private static IEnumerable<IRegistration> Components()
        {
            yield return Component
                .For<IContextFactory>()
                .ImplementedBy<ContextFactory>()
                .LifestyleScoped();

            yield return Component
                .For<IUnitOfWork>()
                .UsingFactoryMethod((kernel) =>
                {
                    var factory = kernel.Resolve<IContextFactory>();
                    var context = factory.Create();
                    return new EfUnitOfWork(context);
                })
                .LifestyleScoped();
        }
    }
}