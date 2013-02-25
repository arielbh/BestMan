using System.Windows;
using BestManApp.Model;
using Microsoft.Phone.UserData;
using SuiteValue.UI.MVVM;
namespace BestManApp.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private Contact _contact;

        public Contact Contact
        {
            get { return _contact; }
            set
            {
                if (value != _contact)
                {
                    _contact = value;
                    OnPropertyChanged(() => Contact);
                }
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged(() => IsSelected);
                }
            }
        }

        private bool _isInvited;

        public bool IsInvited
        {
            get { return _isInvited; }
            set
            {
                if (value != _isInvited)
                {
                    _isInvited = value;
                    OnPropertyChanged(() => IsInvited);
                    OnPropertyChanged(() => IsInvitedVisibility);
                }
            }
        }


        public Visibility IsInvitedVisibility
        {
            get { return IsInvited ? Visibility.Visible : Visibility.Collapsed; }

        }
    }
}