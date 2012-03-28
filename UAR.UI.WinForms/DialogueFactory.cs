using System.Windows.Forms;

using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace UAR.UI.WinForms
{
    class DialogueFactory : IDialogueFactory
    {
        readonly IWindsorContainer _container;

        public DialogueFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public Form Create<T>() where T : Form
        {
            var scope = _container.BeginScope();

            return _container.Resolve<T>(new {scope});
        }
    }
}