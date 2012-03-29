using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeesVM : IDisposable
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

            LoadEmployees();
        }

        void LoadEmployees()
        {
            var hecoEmployees = (
                from e in _unitOfWork.Entities<Employee>()
                where e.EmployeeID < 10
                select _viewModelFactory.Create<EmployeeDetailVM>().Initialize(e)
                ).ToList();
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