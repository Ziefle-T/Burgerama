using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Client.Framework;
using Client.Server.Models;
using Client.Server.Services;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    class LoginController : BaseController
    {
        private LoginViewModel mViewModel;
        private LoginView mView;
        private IUserService mUserService;

        private User mUser;

        public LoginController(IUserService userService)
        {
            mUserService = userService;
        }

        public void SafeExecuteLoginCommand(object obj)
        {
            try
            {
                ExecuteLoginCommand(obj);
            }
            catch (EndpointNotFoundException)
            {
                ShowMessage("Der Server wurde nicht gefunden.");
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
            }
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
                    mUser = loginResult.user;
                    
                    mView.DialogResult = true;
                    mView.Close();
                    return;
                }
                else
                {
                    ShowMessage("Username oder Passwort nicht gefunden, bitte erneut versuchen.");
                }
                
            }
            else
            {
                ShowMessage("Bitte Username und Passwort eingeben.");
            }
        }

        public (bool success, User user) Login()
        {
            mViewModel = new LoginViewModel();
            mViewModel.LoginCommand = new RelayCommand(SafeExecuteLoginCommand);

            mView = new LoginView();
            mView.DataContext = mViewModel;

            bool? result = mView.ShowDialog();
            return (result ?? false, mUser);
        }
    }
}
