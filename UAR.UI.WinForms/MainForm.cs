using System;
using System.Linq;
using System.Windows.Forms;

using UAR.Domain.AdventureWorks;
using UAR.Persistence.Contracts;

namespace UAR.UI.WinForms
{
    public partial class Form1 : Form
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDialogueFactory _dialogueFactory;

        public Form1(IDialogueFactory dialogueFactory)
        {
            _dialogueFactory = dialogueFactory;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dialogueFactory.Create<AW_Dialog>().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _dialogueFactory.Create<NW_Dialog>().Show();
        }
    }
}
