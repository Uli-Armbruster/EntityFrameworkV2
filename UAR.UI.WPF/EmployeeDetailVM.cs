using System;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeeDetailVM : IDisposable, IAmViewModel
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;
        Employee _employee;
        public string Name { get; set; }

        public EmployeeDetailVM(IUnitOfWork unitOfWork, IDisposable scope, Employee employee)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            _employee = employee;
            Name = string.Format("{0} {1}", employee.FirstName, employee.LastName);
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