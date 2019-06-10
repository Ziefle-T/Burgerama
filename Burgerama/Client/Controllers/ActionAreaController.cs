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
    public abstract class ActionAreaController<T> where T : ActionAreaViewModel
    {
        protected T mViewModel;

        public virtual T Initialize()
        {
            mViewModel = App.Container.Resolve<T>();

            mViewModel.NewCommand = new RelayCommand(ExecuteNewCommand, CanExecuteNewCommand);
            mViewModel.EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
            mViewModel.SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            mViewModel.DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);

            return mViewModel;
        }

        public virtual void ExecuteNewCommand(object obj)
        {
            throw new NotImplementedException("Not implemented New Command");
        }
        public virtual bool CanExecuteNewCommand(object obj)
        {
            return false;
        }

        public virtual void ExecuteEditCommand(object obj)
        {
            throw new NotImplementedException("Not implemented Edit Command");
        }
        public virtual bool CanExecuteEditCommand(object obj)
        {
            return false;
        }

        public virtual void ExecuteSaveCommand(object obj)
        {
            throw new NotImplementedException("Not implemented Save Command");
        }
        public virtual bool CanExecuteSaveCommand(object obj)
        {
            return false;
        }

        public virtual void ExecuteDeleteCommand(object obj)
        {
            throw new NotImplementedException("Not implemented Delete Command");
        }
        public virtual bool CanExecuteDeleteCommand(object obj)
        {
            return false;
        }
    }
}
