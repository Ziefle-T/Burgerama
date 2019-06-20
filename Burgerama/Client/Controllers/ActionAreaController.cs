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

        protected string mUpdateConflictMessage = "Ein unbekannter Fehler ist aufgetreten.";

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
            catch (EndpointNotFoundException)
            {
                ShowMessage("Der Server wurde nicht gefunden.");
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
            catch (EndpointNotFoundException)
            {
                ShowMessage("Der Server wurde nicht gefunden.");
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
            catch (EndpointNotFoundException)
            {
                ShowMessage("Der Server wurde nicht gefunden.");
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
            catch (EndpointNotFoundException)
            {
                ShowMessage("Der Server wurde nicht gefunden.");
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

        protected virtual void ResetView()
        {
            Initialize();
        }

        protected void HandleUpdateResult(int updateResult)
        {
            switch (updateResult)
            {
                case 0:
                    ResetView();
                    break;
                case 1:
                    ShowMessage(mUpdateConflictMessage);
                    break;
                case 2:
                    ShowMessage("Es konnte nicht gespeichert werden.\n" +
                                "Das Objekt wurde an anderer Stelle geändert.\n" +
                                "Laden Sie die Seite neu und versuchen es erneut.");
                    break;
                case 3:
                    ShowMessage("Es konnte nicht gespeichert werden.\n" +
                                "Das veränderte Objekt wurde auf dem Server nichtmehr gefunen.");
                    break;
            }
        }
    }
}
