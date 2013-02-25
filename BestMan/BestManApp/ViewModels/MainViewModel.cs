using SuiteValue.UI.MVVM;
using SuiteValue.UI.WP8;

namespace BestManApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Parts = new CommandableViewModelBase[]
            {
                new InvitationsViewModel(),
                new GiftsViewModel()
            };
        }
        private CommandableViewModelBase[] _parts;

        public CommandableViewModelBase[] Parts
        {
            get { return _parts; }
            set
            {
                if (value != _parts)
                {
                    _parts = value;
                    OnPropertyChanged(() => Parts);
                }
            }
        }

        private CommandableViewModelBase _selectedPart;

        public CommandableViewModelBase SelectedPart
        {
            get { return _selectedPart; }
            set
            {
                if (value != _selectedPart)
                {
                    _selectedPart = value;
                    OnPropertyChanged(() => SelectedPart);
                    if (SelectedPart != null)
                    {
                        SelectedPart.Activate();
                    }
                }
            }
        }
         
    }
}