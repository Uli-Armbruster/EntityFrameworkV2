using System;
using System.Linq;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;

namespace UAR.UI.WPF
{
    public class NorthwindVM : IDisposable
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;
        public string Text { get; set; }

        public NorthwindVM(IUnitOfWork unitOfWork, IDisposable scope)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            LoadText();
        }

        void LoadText()
        {
            Text = string.Format("Firstname of first employee: {0}", _unitOfWork.Entities<Employees>().First().FirstName);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}