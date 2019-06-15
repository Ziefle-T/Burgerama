using Client.Server.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    class UserViewModel : ActionAreaViewModel
    {
        private ObservableCollection<User> mUsers;
        public ObservableCollection<User> Users
        {
            get { return mUsers; }
            set
            {
                mUsers = value;
                OnPropertyChanged();
            }
        }
        public User SelectedUser { get; set; }

        public bool CanEditUser
        {
            get { return EditingUser != null; }
        }

        private User mEditingUser;
        public User EditingUser
        {
            get { return mEditingUser; }
            set
            {
                mEditingUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanEditUser));
            }
        }
        public ICommand AddArticleCommand { get; set; }
        public ICommand RemoveArticleCommand { get; set; }
    }
}
