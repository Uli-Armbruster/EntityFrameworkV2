using System.Windows.Forms;

namespace UAR.UI.Contracts
{
    public interface IDialogFactory
    {
        Form Create<T>() where T : Form;
    }
}