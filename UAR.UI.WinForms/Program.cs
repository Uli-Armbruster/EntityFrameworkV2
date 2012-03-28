using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
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
}