using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SuiteValue.UI.WP8;

namespace BestManApp.ViewModels
{
    public class GiftsViewModel : CommandableViewModelBase
    {
        public GiftsViewModel()
        {
            Header = "Gifts";
        }


        public override void Activate()
        {
            base.Activate();
            if (PhoneApplicationService.Current.State.ContainsKey("Contacts"))
            {
                Contacts = PhoneApplicationService.Current.State["Contacts"] as List<ContactViewModel>;
            }
        }

        private List<ContactViewModel> _contacts;

        public List<ContactViewModel> Contacts
        {
            get { return _contacts; }
            set
            {
                if (value != _contacts)
                {
                    _contacts = value;
                    OnPropertyChanged(() => Contacts);
                }
            }
        }


        private ContactViewModel _selectedContact;

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                if (value != _selectedContact)
                {
                    _selectedContact = value;
                    OnPropertyChanged(() => SelectedContact);
                    if (SelectedContact != null)
                    {
                        DisplayContactGiftEditor(SelectedContact);
                    }
                }
            }
        }

        private void DisplayContactGiftEditor(ContactViewModel selectedContact)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                ContentTemplate = (DataTemplate)App.Current.Resources["ContactGiftEditor"],
                Content = selectedContact,
                LeftButtonContent = "Save",
                RightButtonContent = "Cancel",
                IsFullScreen = false
            };

            messageBox.Dismissed += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        // Do something.
                        ClearSelection();
                        break;
                    case CustomMessageBoxResult.RightButton:
                        //Reset
                        ClearSelection();
                        selectedContact.Gift.Amount = 0;
                        break;
                    case CustomMessageBoxResult.None:
                        ClearSelection();
                        selectedContact.Gift.Amount = 0;
                        break;
                    default:
                        break;
                }
            };

            messageBox.Show();
        }

        private void ClearSelection()
        {
            SelectedContact = null;
        }
    }
}