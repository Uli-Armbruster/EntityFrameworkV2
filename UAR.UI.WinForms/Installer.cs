using System.Collections.Generic;
using System.Linq;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

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
            container.Register(Component.For<IWindsorContainer>().Instance(container));
        }

        private static IEnumerable<IRegistration> Components()
        {
            
            yield return Component.For<IDialogueFactory>().ImplementedBy<DialogueFactory>();

            yield return Component.For<Form1>().ImplementedBy<Form1>().LifestyleTransient();
            yield return Component.For<AW_Dialog>().ImplementedBy<AW_Dialog>().LifestyleTransient();
            yield return Component.For<NW_Dialog>().ImplementedBy<NW_Dialog>().LifestyleTransient();

            yield return Component.For<IBusinessLogic>().ImplementedBy<BusinessLogic>().LifestyleTransient();

        }
    }
}