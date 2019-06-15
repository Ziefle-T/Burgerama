using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Server.Models;
using Client.Server.Services;
using Client.ViewModels;

namespace Client.Controllers
{
    class UserViewController : ActionAreaController<UserViewModel>
    {
        private IUserService mUserService;

        public UserViewController(
            IUserService userService

        ) : base()
        {
            mUserService = userService;
        }
        public override UserViewModel Initialize()
        {
            var retVal = base.Initialize();

            retVal.Users = new ObservableCollection<User>(mUserService.GetAll());
            return retVal;
        }
        public override bool CanExecuteDeleteCommand(object obj)
        {
            return mViewModel.SelectedUser != null;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return mViewModel.SelectedUser != null;
        }
        public override bool CanExecuteNewCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteSaveCommand(object obj)
        {
            return true;
        }

        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedUser == null)
            {
                ShowMessage("Nichts zum löschen ausgewählt.");
                return;
            }

            mUserService.Delete(mViewModel.SelectedUser.Id);
            ResetView();
        }

        public override void ExecuteEditCommand(object obj)
        {
            mViewModel.EditingUser = mViewModel.SelectedUser;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingUser = new User()
            {
                Id = 0,
                Username = "",
                Firstname = "",
                Lastname = "",
                IsAdmin = false

            };
        }

        public override void ExecuteSaveCommand(object obj)
        {
            if (mViewModel.EditingUser == null)
            {
                ShowMessage("Es gibt nichts zu speichern.");
                return;
            }

            if (mViewModel.EditingUser.Id == 0)
            {
                mUserService.Add(mViewModel.EditingUser);
            }
            else
            {
                mUserService.UpdateUser(mViewModel.EditingUser.Id, mViewModel.EditingUser);
            }

            ResetView();
        }
        private void ResetView()
        {
            mViewModel.SelectedUser = null;
            mViewModel.EditingUser = null;
            mViewModel.Users = new ObservableCollection<User>(mUserService.GetAll());
        }
    }
}
