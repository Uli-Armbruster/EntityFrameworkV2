using System;
using System.Windows;

using UAR.Infrastructure;

namespace UAR.UI.WPF
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var bootstrapper = new Bootstrapper())
            {
                bootstrapper.RegisterComponents().RunStartupConfiguration();
                var window = bootstrapper.Container.Resolve<MainWindow>();
                var app = new Application();
                app.Run(window);
            }
        }
    }
}