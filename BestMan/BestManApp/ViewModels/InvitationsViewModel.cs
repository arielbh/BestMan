using System;
using System.Collections.Generic;
using BestManApp.Model;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;
using SuiteValue.UI.MVVM;
using System.Linq;
using SuiteValue.UI.WP8;
using ApplicationBarIconButton = SuiteValue.UI.WP8.Controls.ApplicationBarIconButton;


namespace BestManApp.ViewModels
{
    public class InvitationsViewModel : CommandableViewModelBase
    {
        public InvitationsViewModel()
        {
            Header = "Invite";

            AppbarCommands = new[]
            {
                new ApplicationBarIconButton
                {
                    Command = SendInviteCommand,
                    IconUri = new Uri("/Assets/Icons/feature.email.png", UriKind.Relative),
                    Text = "Send"
                }
            };

        }


        public override void Activate()
        {
            base.Activate();
            Init();

        }

        private async void Init()
        {
            var contacts = await App.ContactService.GetAllContacts();
            Contacts =
                contacts.GroupBy(c => c.DisplayName.First(), contact => contact)
                        .Select(g => new Group<ContactViewModel>(g.Key.ToString(), g.Select(c => new ContactViewModel { Contact = c }))).ToList();
        }

        private List<Group<ContactViewModel>> _contacts;

        public List<Group<ContactViewModel>> Contacts
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

        private DelegateCommand _sendInviteCommand;

        public DelegateCommand SendInviteCommand
        {
            get
            {
                return _sendInviteCommand ?? (_sendInviteCommand = new DelegateCommand(
                                                     () =>
                                                     {
                                                         var list = Contacts.SelectMany(g => g)
                                                                            .Where(c => c.IsSelected)
                                                                            .ToList();


                                                         foreach (
                                                             var conact in list)
                                                         {
                                                             conact.IsInvited = true;
                                                         }
                                                         PhoneApplicationService.Current.State["Contacts"] = list;

                                                     }));
            }
        }


    }
}