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
    class ChangePasswordController : BaseController
    {
        private IUserService mUserService;

        private ChangepasswordViewModel mChangepasswordViewModel;
        private ChangePasswordWindow mView;

        public ChangePasswordController(IUserService userService)
        {
            mUserService = userService;
        }

        public void SafeExecuteChangeCommand(object obj)
        {
            try
            {
                ExecuteChangeCommand(obj);
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
            }
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
                ShowMessage("Bitte Passwort eingeben.");
                return;
            }

            if (newPasswordBox.Password == null ||
                newPasswordBox.Password == string.Empty)
            {
                ShowMessage("Bitte neues Passwort eingeben.");
                return;
            }

            if (newPasswordWBox.Password == null ||
                newPasswordWBox.Password == string.Empty)
            {
                ShowMessage("Bitte neues Passwort wiederholen.");
                return;
            }

            if (newPasswordBox.Password != newPasswordWBox.Password)
            {
                ShowMessage("Das wiederholte Passwort entspricht nicht dem neuen Passwort.");
                return;
            }

            int updateResult =
                mUserService.UpdatePassword(App.LoggedInUser.Id, passwordBox.Password, newPasswordBox.Password);

            switch (updateResult)
            {
                case 0:
                    mView.Close();
                    break;
                case 1:
                    ShowMessage("Bitte korrektes Passwort eingeben.");
                    break;
                case 2:
                    ShowMessage("Der Benutzer wurde an anderer Stelle geändert.\n" +
                                "Melden Sie sich erneut an und versuchen es nochmals.");
                    break;
                case 3:
                    ShowMessage("Der Benutzer wurde nicht gefunden.");
                    break;
            }
        }

        public void ChangePassword()
        {
            mChangepasswordViewModel = new ChangepasswordViewModel();
            mChangepasswordViewModel.ChangeCommand = new RelayCommand(SafeExecuteChangeCommand);

            mView = new ChangePasswordWindow();
            mView.DataContext = mChangepasswordViewModel;

            mView.ShowDialog();
        }
    }
}
