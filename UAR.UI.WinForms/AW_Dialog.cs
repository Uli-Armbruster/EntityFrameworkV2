using System;
using System.Linq;
using System.Windows.Forms;

using UAR.Domain.AdventureWorks;
using UAR.Persistence.Contracts;

namespace UAR.UI.WinForms
{
    public partial class AW_Dialog : Form
    {
        readonly IBusinessLogic _businessLogic;
        readonly IDisposable _scope;
        readonly IUnitOfWork _unitOfWork;

        public AW_Dialog(IUnitOfWork unitOfWork, IDisposable scope, IBusinessLogic businessLogic)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            _businessLogic = businessLogic;
            InitializeComponent();
        }

        void Dialog1_Load(object sender, EventArgs e)
        {
            var name = _businessLogic.GetCustomer();
            var address = (from a in _unitOfWork.Entities<Address>()
                               select a).First();
            label1.Text = string.Format("BI Logic: {0}, Dialog Logic: {1}", name, address.City);
        }

        protected override void OnClosed(EventArgs e)
        {
            _scope.Dispose();
            base.OnClosed(e);
        }
    }
}