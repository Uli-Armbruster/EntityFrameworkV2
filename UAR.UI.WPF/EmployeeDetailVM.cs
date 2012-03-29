using System;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeeDetailVM : IAmViewModel
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public EmployeeDetailVM(IUnitOfWork unitOfWork, Employee employee)
        {
            _unitOfWork = unitOfWork;

            Name = string.Format("{0} {1}", employee.FirstName, employee.LastName);
            Phone = employee.HomePhone;
            Country = employee.Country;
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}