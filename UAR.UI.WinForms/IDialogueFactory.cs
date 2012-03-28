using System.Windows.Forms;

namespace UAR.UI.WinForms
{
    public interface IDialogueFactory
    {
        Form Create<T>() where T : Form;
    }
}