using System.Collections.Generic;
using System.Linq;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace UAR.UI.WPF
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
            container.Register(Component.For<IWindsorContainer>().Instance(container));
        }

        private static IEnumerable<IRegistration> Components()
        {

            yield return Component.For<IViewModelFactory>().ImplementedBy<ViewModelFactory>();
            yield return Component.For<MainWindow>().ImplementedBy<MainWindow>().LifestyleTransient();
            yield return Component.For<AdventureWorksVM>().ImplementedBy<AdventureWorksVM>().LifestyleTransient();
            yield return Component.For<NorthwindVM>().ImplementedBy<NorthwindVM>().LifestyleTransient();
        }
    }
}