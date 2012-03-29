using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using UAR.UI.Contracts;

namespace UAR.UI.WinForms
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
            
            yield return Component.For<IDialogFactory>().ImplementedBy<DialogFactory>();

            //Todo: Register all Form Types
            yield return Classes.FromThisAssembly()
                .BasedOn<Form>()
                .WithServiceSelf()
                .LifestyleTransient();
        }
    }
}