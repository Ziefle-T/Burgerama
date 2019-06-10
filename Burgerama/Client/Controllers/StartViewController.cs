using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Client.Framework;
using Client.ViewModels;

namespace Client.Controllers
{
    class StartViewController : ActionAreaController<StartViewModel>
    {
        public override StartViewModel Initialize()
        {
            var ret = base.Initialize();

            mViewModel.ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand);

            return ret;
        }

        public void ExecuteChangePasswordCommand(object obj)
        {
            var changePasswordController = App.Container.Resolve<ChangePasswordController>();
            changePasswordController.ChangePassword();
        }
    }
}
