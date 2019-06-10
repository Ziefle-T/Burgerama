using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string mUserName = "";
        public string UserName
        {
            get { return mUserName; }
            set
            {
                mUserName = value;
                mShowUserNameLabel = value == "";
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowUsernameLabel));
            }
        }

        private string mPassword = "";
        public string Password
        {
            get { return mPassword;}
            set
            {
                mPassword = value;
                mShowPasswordLabel = value == "";
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowPasswordLabel));
            }
        }

        private bool mShowUserNameLabel = true;
        public Visibility ShowUsernameLabel
        {
            get { return mShowUserNameLabel ? Visibility.Visible : Visibility.Hidden; }
            set
            {
                mShowUserNameLabel = value == Visibility.Visible;
                OnPropertyChanged();
            }
        }

        private bool mShowPasswordLabel = true;
        public Visibility ShowPasswordLabel
        {
            get { return mShowPasswordLabel ? Visibility.Visible : Visibility.Hidden; }
            set
            {
                mShowPasswordLabel = value == Visibility.Visible;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }
    }
}
