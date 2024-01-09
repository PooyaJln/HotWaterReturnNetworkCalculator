using System.Windows;
using HotWaterReturnNetworkCalculator.ViewModel;
namespace HotWaterReturnNetworkCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
        }
    }
}