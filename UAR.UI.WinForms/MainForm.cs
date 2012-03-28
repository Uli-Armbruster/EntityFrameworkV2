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

        public Form1(IUnitOfWork unitOfWork, IDialogueFactory dialogueFactory)
        {
            _unitOfWork = unitOfWork;
            _dialogueFactory = dialogueFactory;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                var contact = (from c in _unitOfWork.Entities<Contact>() select c).First();
                MessageBox.Show(contact.EmailAddress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dialogueFactory.Create<Dialog1>().Show();
        }
    }
}
