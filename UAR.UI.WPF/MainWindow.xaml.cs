using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace UAR.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        readonly IViewModelFactory _viewModelFactory;

        NorthwindVM _northwindViewModel;
        public NorthwindVM NorthwindViewModel
        {
            get
            {
                return _northwindViewModel;
            }
            set
            {
                _northwindViewModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NorthwindViewModel"));
            }
        }

        AdventureWorksVM _adventureWorksViewModel;
        public AdventureWorksVM AdventureWorksViewModel
        {
            get
            {
                return _adventureWorksViewModel;
            }
            set
            {
                _adventureWorksViewModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AdventureWorksViewModel"));
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
            if (NorthwindViewModel == null)
                NorthwindViewModel = _viewModelFactory.Create<NorthwindVM>();
        }

        void Button_Click_AdventureWorks(object sender, RoutedEventArgs e)
        {
            if (AdventureWorksViewModel == null)
                AdventureWorksViewModel = _viewModelFactory.Create<AdventureWorksVM>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (NorthwindViewModel == null)
                return;

            NorthwindViewModel.Dispose();
            NorthwindViewModel = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (AdventureWorksViewModel == null)
                return;

            AdventureWorksViewModel.Dispose();
            AdventureWorksViewModel = null;
        }


    }
}
