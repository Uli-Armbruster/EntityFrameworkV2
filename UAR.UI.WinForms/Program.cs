using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace UAR.UI.WinForms
{
    static class Program
    {
        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var container = new WindsorContainer())
            {
                var appDomainDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                container.Install(FromAssembly.InDirectory(new AssemblyFilter(appDomainDirectory)));

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (container.BeginScope())
                {
                    Application.Run(container.Resolve<Form1>());
                }
            }
        }
    }

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
            yield return Component.For<Form1>().ImplementedBy<Form1>();

        }
    }
}