using System.Windows.Forms;

namespace UAR.UI.WinForms
{
    public interface IDialogFactory
    {
        Form Create<T>() where T : Form;
    }
}