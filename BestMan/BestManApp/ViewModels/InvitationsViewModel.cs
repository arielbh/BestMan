using System;
using System.Collections.Generic;
using BestManApp.Model;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;
using SuiteValue.UI.MVVM;
using System.Linq;
using SuiteValue.UI.WP8;

namespace BestManApp.ViewModels
{
    public class InvitationsViewModel : CommandableViewModelBase
    {
        public InvitationsViewModel()
        {
            Header = "Invite";
        }
    }
}