using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Client.Framework;
using Client.ViewModels;

namespace Client.Controllers
{
    public abstract class ActionAreaController<T> : BaseController where T : ActionAreaViewModel
    {
        protected T mViewModel;

        public T SafeInitialize()
        {
            try
            {
                return Initialize();
            }
            catch (EndpointNotFoundException e)
            {
                ShowMessage("Der Server wurde nicht gefunden.");
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
            }

            return null;
        }

        public virtual T Initialize()
        {
            mViewModel = App.Container.Resolve<T>();

            mViewModel.NewCommand = new RelayCommand(SafeExecuteNewCommand, CanExecuteNewCommand);
            mViewModel.EditCommand = new RelayCommand(SafeExecuteEditCommand, CanExecuteEditCommand);
            mViewModel.SaveCommand = new RelayCommand(SafeExecuteSaveCommand, CanExecuteSaveCommand);
            mViewModel.DeleteCommand = new RelayCommand(SafeExecuteDeleteCommand, CanExecuteDeleteCommand);

            return mViewModel;
        }

        private void SafeExecuteNewCommand(object obj)
        {
            try
            {
                ExecuteNewCommand(obj);
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
                return;
            }
        }
        public virtual void ExecuteNewCommand(object obj)
        {
            throw new NotImplementedException("Not implemented New Command");
        }
        public virtual bool CanExecuteNewCommand(object obj)
        {
            return false;
        }

        private void SafeExecuteEditCommand(object obj)
        {
            try
            {
                ExecuteEditCommand(obj);
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
                return;
            }
        }
        public virtual void ExecuteEditCommand(object obj)
        {
            throw new NotImplementedException("Not implemented Edit Command");
        }
        public virtual bool CanExecuteEditCommand(object obj)
        {
            return false;
        }

        private void SafeExecuteSaveCommand(object obj)
        {
            try
            {
                ExecuteSaveCommand(obj);
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
                return;
            }
        }
        public virtual void ExecuteSaveCommand(object obj)
        {
            throw new NotImplementedException("Not implemented Save Command");
        }
        public virtual bool CanExecuteSaveCommand(object obj)
        {
            return false;
        }

        private void SafeExecuteDeleteCommand(object obj)
        {
            try
            {
                ExecuteDeleteCommand(obj);
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
                return;
            }
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
