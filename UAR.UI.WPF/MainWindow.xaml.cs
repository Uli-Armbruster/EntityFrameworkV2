using System.ComponentModel;
using System.Linq;
using System.Windows;

using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, IAmViewModel
    {
        readonly IViewModelFactory _viewModelFactory;

        EmployeesVM _employeesViewModel;
        public EmployeesVM EmployeesViewModel
        {
            get
            {
                return _employeesViewModel;
            }
            set
            {
                _employeesViewModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EmployeesViewModel"));
            }
        }

        public MainWindow(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click_Northwind(object sender, RoutedEventArgs e)
        {
            if (EmployeesViewModel == null)
                EmployeesViewModel = _viewModelFactory.Create<EmployeesVM>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (EmployeesViewModel == null)
                return;

            EmployeesViewModel.Dispose();
            EmployeesViewModel = null;
        }

    }
}
