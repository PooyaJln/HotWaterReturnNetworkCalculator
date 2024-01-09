
using System.Collections.ObjectModel;
using HotWaterReturnNetworkCalculator.Model;
using HotWaterReturnNetworkCalculator.MVVM;


namespace HotWaterReturnNetworkCalculator.ViewModel
{

    internal class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<PipeNetworkElement> PipeNetworkElements { get; set; }

        public MainWindowViewModel() { }

        private PipeNetworkElement selectedPipeNetworkElement;


        public PipeNetworkElement SelectedItem
        {
            get { return selectedPipeNetworkElement; }
            set 
            {
                selectedPipeNetworkElement = value;
                OnPropertyChanged();
            }
        }

       

    }
}


