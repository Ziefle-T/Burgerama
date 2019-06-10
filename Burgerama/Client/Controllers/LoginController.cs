using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Client.Framework;
using Client.Server.Services;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    class LoginController
    {
        private LoginViewModel mViewModel;
        private LoginView mView;
        private IUserService mUserService;

        private bool mIsAdmin = false;

        public LoginController(IUserService userService)
        {
            mUserService = userService;
        }

        public void ExecuteLoginCommand(object obj)
        {
            var passwordBox = obj as PasswordBox;

            if (mViewModel.UserName != null &&
                mViewModel.UserName != "" &&
                passwordBox.Password != null &&
                passwordBox.Password != "")
            {
                var loginResult = mUserService.Login(mViewModel.UserName, passwordBox.Password);
                if (loginResult.success)
                {
                    mIsAdmin = loginResult.isAdmin;
                    
                    mView.DialogResult = true;
                    mView.Close();
                    return;
                }
                
            }
        }

        public (bool success, bool isAdmin) Login()
        {
            mViewModel = new LoginViewModel();
            mViewModel.LoginCommand = new RelayCommand(ExecuteLoginCommand);

            mView = new LoginView();
            mView.DataContext = mViewModel;

            bool? result = mView.ShowDialog();
            return (result ?? false, mIsAdmin);
        }
    }
}
