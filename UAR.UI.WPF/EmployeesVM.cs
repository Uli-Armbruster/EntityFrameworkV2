using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;
using System.ComponentModel;

namespace UAR.UI.WPF
{
    public class EmployeesVM : IDisposable, IAmViewModel
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDisposable _scope;
        readonly IViewModelFactory _viewModelFactory;

        public ObservableCollection<EmployeeDetailVM> HecoEmployees { get; set; }

        EmployeeDetailVM _selectedItem;
        public EmployeeDetailVM SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        public EmployeesVM(IUnitOfWork unitOfWork, IDisposable scope, IViewModelFactory viewModelFactory)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            _viewModelFactory = viewModelFactory;

            LoadEmployees();
        }

        void LoadEmployees()
        {
            var employees = (
                from e in _unitOfWork.Entities<Employee>()
                where e.EmployeeID < 10
                select e
                ).ToList();

            if (HecoEmployees == null)
                HecoEmployees = new ObservableCollection<EmployeeDetailVM>();
            else
                HecoEmployees.Clear();

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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}