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
    }
}