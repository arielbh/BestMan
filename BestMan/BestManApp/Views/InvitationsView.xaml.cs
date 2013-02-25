using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BestManApp.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BestManApp.Views
{
    public partial class InvitationsView : UserControl
    {
        public InvitationsView()
        {
            InitializeComponent();
        }

        private void LongListMultiSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ContactViewModel vm in e.AddedItems)
            {
                vm.IsSelected = true;
            }
            foreach (ContactViewModel vm in e.RemovedItems)
            {
                vm.IsSelected = false;
            }
        }
    }
}
