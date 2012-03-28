using System;
using System.IO;
using System.Reflection;
using System.Windows;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace UAR.UI.WPF
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            var container = new WindsorContainer();
            var appDomainDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            container.Install(FromAssembly.InDirectory(new AssemblyFilter(appDomainDirectory)));

            var window = container.Resolve<MainWindow>();
            var app = new Application();
            app.Run(window);
        }
    }
}