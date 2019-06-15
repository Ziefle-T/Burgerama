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
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public User EditingUser;
        public ICommand AddArticleCommand { get; set; }
        public ICommand RemoveArticleCommand { get; set; }
    }
}
