using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using Client.Server.Models;
using Client.Server.Services;
using Client.ViewModels;

namespace Client.Controllers
{
    class DriverViewController : ActionAreaController<DriverViewModel>
    {
        private IDriverService mDriverService;
        private IAreaService mAreaService;

        public DriverViewController(
            IDriverService driverService,
            IAreaService   areaService
        ) : base()
        {
            mDriverService = driverService;
            mAreaService = areaService;
        }
        public override DriverViewModel Initialize()
        {
            var retVal = base.Initialize();

            retVal.Drivers = new ObservableCollection<Driver>(mDriverService.GetAll());
            retVal.Areas = new ObservableCollection<Area>(mAreaService.GetAll());

            return retVal;
        }
        public override bool CanExecuteDeleteCommand(object obj)
        {
            return mViewModel.SelectedDriver != null;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return mViewModel.SelectedDriver != null;
        }
        public override bool CanExecuteNewCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteSaveCommand(object obj)
        {
            return mViewModel.EditingDriver != null;
        }

        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedDriver == null)
            {
                ShowMessage("Bitte einen Fahrer zum löschen auswählen.");
                return;
            }

            if (mDriverService.Delete(mViewModel.SelectedDriver.Id))
            {
                ResetView();
            }
            else
            {
                ShowMessage("Der Fahrer konnte nicht gelöscht werden.\n" +
                            "Bitte löschen Sie zuerst alle mit dem Fahrer verbundenen Bestellungen.");
            }
        }

        public override void ExecuteEditCommand(object obj)
        {
            mViewModel.EditingDriver = mViewModel.SelectedDriver;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingDriver = new Driver()
            {
                Id = 0,
                EmployeeNumber = 0,
                Areas = {},
                FirstName = "",
                LastName = ""
            };
        }

        public override void ExecuteSaveCommand(object obj)
        {
            if (mViewModel.EditingDriver == null)
            {
                ShowMessage("Es gibt nichts zu speichern.");
                return;
            }

            if (mViewModel.EditingDriver.EmployeeNumber <= 0)
            {
                ShowMessage("Die Personal-Nr. muss größer als 0 sein.");
                return;
            }

            if (mViewModel.EditingDriver.FirstName == "")
            {
                ShowMessage("Bitte geben Sie einen Vornamen ein.");
                return;
            }

            if (mViewModel.EditingDriver.LastName == "")
            {
                ShowMessage("Bitte geben Sie einen Nachamen ein.");
                return;
            }

            bool success = false;
            if (mViewModel.EditingDriver.Id == 0)
            {
                success = mDriverService.Add(mViewModel.EditingDriver);
            }
            else
            {
                success = mDriverService.UpdateDriver(mViewModel.EditingDriver.Id, mViewModel.EditingDriver);
            }

            if (!success)
            {
                ShowMessage("Die Personal-Nr. muss eindeutig sein.");
                return;
            }

            ResetView();
        }
        private void ResetView()
        {
            mViewModel.SelectedDriver = null;
            mViewModel.EditingDriver = null;
            mViewModel.Drivers = new ObservableCollection<Driver>(mDriverService.GetAll());
            mViewModel.Areas = new ObservableCollection<Area>(mAreaService.GetAll());
        }
    }
}

