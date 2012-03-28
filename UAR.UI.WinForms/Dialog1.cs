using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UAR.Domain.AdventureWorks;
using UAR.Persistence.Contracts;

namespace UAR.UI.WinForms
{
    public partial class Dialog1 : Form
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;
        readonly IBusinessLogic _businessLogic;

        public Dialog1(IUnitOfWork unitOfWork, IDisposable scope, IBusinessLogic businessLogic)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            _businessLogic = businessLogic;
            InitializeComponent();
        }

        private void Dialog1_Load(object sender, EventArgs e)
        {
            var name = _businessLogic.GetCustomer();
            var address = (from a in _unitOfWork.Entities<Address>() select a).First();
            MessageBox.Show(string.Format("BI Logic: {0}, Dialog Logic: {1}",name ,address.City));
        }

        protected override void OnClosed(EventArgs e)
        {
            _scope.Dispose();
            base.OnClosed(e);
        }
    }
}
