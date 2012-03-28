using System.Windows.Forms;

using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace UAR.UI.WinForms
{
    class DialogFactory : IDialogFactory
    {
        readonly IWindsorContainer _container;

        public DialogFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public Form Create<T>() where T : Form
        {
            var scope = _container.BeginScope();

            var result = _container.Resolve<T>();
            result.Closed += (s, a) => scope.Dispose();

            return result;
        }
    }
}