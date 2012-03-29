using System;
using System.Linq;
using System.Windows.Forms;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;

namespace UAR.UI.WinForms
{
    public partial class NW_Dialog : Form
    {
        readonly IUnitOfWork _unitOfWork;

        public NW_Dialog(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
        }

        void NW_Dialog_Load(object sender, EventArgs e)
        {
            label1.Text = _unitOfWork.Entities<Employee>().First().FirstName;
        }
    }
}