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
    class ChangePasswordController
    {
        private IUserService mUserService;

        private ChangepasswordViewModel mChangepasswordViewModel;
        private ChangePasswordWindow mView;

        public ChangePasswordController(IUserService userService)
        {
            mUserService = userService;
        }

        public void ExecuteChangeCommand(object obj)
        {
            var passwordBoxes = obj as object[];

            PasswordBox passwordBox = passwordBoxes[0] as PasswordBox;
            PasswordBox newPasswordBox = passwordBoxes[1] as PasswordBox;
            PasswordBox newPasswordWBox = passwordBoxes[2] as PasswordBox;

            if (passwordBox.Password == null ||
                passwordBox.Password == string.Empty)
            {
                return;
            }

            if (newPasswordBox.Password == null ||
                newPasswordBox.Password == string.Empty)
            {
                return;
            }

            if (newPasswordWBox.Password == null ||
                newPasswordWBox.Password == string.Empty)
            {
                return;
            }

            if (newPasswordBox.Password != newPasswordWBox.Password)
            {
                return;
            }

            if (mUserService.UpdatePassword(App.LoggedInUser.Id, passwordBox.Password, newPasswordBox.Password))
            {
                mView.Close();
            }
        }

        public void ChangePassword()
        {
            mChangepasswordViewModel = new ChangepasswordViewModel();
            mChangepasswordViewModel.ChangeCommand = new RelayCommand(ExecuteChangeCommand);

            mView = new ChangePasswordWindow();
            mView.DataContext = mChangepasswordViewModel;

            mView.ShowDialog();
        }
    }
}
