using System;
using System.Windows.Forms;

using Castle.MicroKernel.Lifestyle;

using UAR.Infrastructure;

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
            using (var bootstrapper = new Bootstrapper())
            {
                bootstrapper.RegisterComponents().RunStartupConfiguration();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (bootstrapper.Container.BeginScope())
                {
                    Application.Run(bootstrapper.Container.Resolve<Form1>());
                }

            }
        }
    }
}