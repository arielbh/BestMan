﻿using System.Windows;
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
    }
}