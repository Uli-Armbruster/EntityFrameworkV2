using System;
using System.Linq;
using System.Windows.Forms;

using UAR.UI.Contracts;

namespace UAR.UI.WinForms
{
    public partial class Form1 : Form
    {
        readonly IDialogFactory _dialogFactory;

        public Form1(IDialogFactory dialogFactory)
        {
            _dialogFactory = dialogFactory;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dialogFactory.Create<AW_Dialog>().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _dialogFactory.Create<NW_Dialog>().Show();
        }
    }
}
