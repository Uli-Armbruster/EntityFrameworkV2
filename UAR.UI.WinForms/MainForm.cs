using System;
using System.Linq;
using System.Windows.Forms;

using UAR.Persistence.ORM;

namespace UAR.UI.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new AdventureWorksContext())
            {
                var contact = (from c in context.Contact
                         select c).First();

                MessageBox.Show(contact.EmailAddress);
            }
        }
    }
}
