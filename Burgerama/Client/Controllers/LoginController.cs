using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    class LoginController
    {
        private LoginViewModel mViewModel;

        public void ExecuteLoginCommand(object obj)
        {
            Console.Out.WriteLine("Login");
        }

        public void ExecutePasswordChangedCommand(object obj)
        {
            Console.WriteLine("changed");
        }

        public bool Login()
        {
            mViewModel = new LoginViewModel();
            mViewModel.LoginCommand = new RelayCommand(ExecuteLoginCommand);
            mViewModel.PasswordChangedCommand = new RelayCommand(ExecutePasswordChangedCommand);

            LoginView view = new LoginView();
            view.DataContext = mViewModel;

            return view.ShowDialog() ?? false;
        }
    }
}
