using System.Collections.Generic;
using System.Linq;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using UAR.UI.Contracts;

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
        }

        private static IEnumerable<IRegistration> Components()
        {
            yield return Component
                .For<IViewModelFactory>()
                .ImplementedBy<ViewModelFactory>()
                .LifestyleSingleton();


            //Todo: Register all components of ViewModels
            yield return Classes.FromThisAssembly()
                .BasedOn<IAmViewModel>()
                .WithServiceSelf()
                .LifestyleTransient();
        }
    }
}