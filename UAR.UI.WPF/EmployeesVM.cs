using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeesVM : IDisposable, IAmViewModel
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;
        readonly IViewModelFactory _viewModelFactory;

        public ObservableCollection<EmployeeDetailVM> HecoEmployees { get; set; }

        public EmployeesVM(IUnitOfWork unitOfWork, IDisposable scope, IViewModelFactory viewModelFactory)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            _viewModelFactory = viewModelFactory;
            HecoEmployees = new ObservableCollection<EmployeeDetailVM>();
            LoadEmployees();
        }

        void LoadEmployees()
        {
            var employees = (
                from e in _unitOfWork.Entities<Employee>()
                where e.EmployeeID < 10
                select e
                ).ToList();

            foreach (var employee in employees)
            {
                HecoEmployees.Add(_viewModelFactory.Create<EmployeeDetailVM>(new {employee}));
            }
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