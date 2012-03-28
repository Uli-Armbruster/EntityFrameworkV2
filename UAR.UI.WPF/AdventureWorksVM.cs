using System;
using System.Linq;

using UAR.Domain.AdventureWorks;
using UAR.Persistence.Contracts;

namespace UAR.UI.WPF
{
    public class AdventureWorksVM : IDisposable
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;
        public string Text { get; set; }
       
        public AdventureWorksVM(IUnitOfWork unitOfWork, IDisposable scope)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            LoadText();
        }

        void LoadText()
        {
            Text = string.Format("Email of first contact: {0}", _unitOfWork.Entities<Contact>().First().EmailAddress);
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