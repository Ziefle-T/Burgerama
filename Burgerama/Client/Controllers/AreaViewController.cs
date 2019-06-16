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
    class AreaViewController : ActionAreaController<AreaViewModel>
    {
        private IAreaService mAreaService;

        public AreaViewController(IAreaService areaService) : base()
        {
            mAreaService = areaService;
        }
        public override AreaViewModel Initialize()
        {
            var retVal = base.Initialize();

            retVal.Areas = new ObservableCollection<Area>(mAreaService.GetAll());

            return retVal;
        }
        public override bool CanExecuteDeleteCommand(object obj)
        {
            return mViewModel.SelectedArea != null;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return mViewModel.SelectedArea != null;
        }
        public override bool CanExecuteNewCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteSaveCommand(object obj)
        {
            return mViewModel.EditingArea != null;
        }

        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedArea == null)
            {
                ShowMessage("Bitte zuerst ein Liefergebiet zum löschen auswählen.");
                return;
            }

            if (mAreaService.Delete(mViewModel.SelectedArea.Id))
            {
                ResetView();
            }
            else
            {
                ShowMessage("Das Liefergebiet konnte nicht gelöscht werden.\n" +
                            "Bitte entfernen Sie zuerst die mit dem Gebiet verbundenen Fahrer.");   
            }
        }

        public override void ExecuteEditCommand(object obj)
        {
            if (mViewModel.SelectedArea == null)
            {
                ShowMessage("Bitte zuerst ein Liefergebiet zum bearbeiten auswählen.");
                return;
            }
            mViewModel.EditingArea = mViewModel.SelectedArea;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingArea = new Area()
            {
                Id = 0,
                Plz = 0,
                Name = ""
            };
        }

        public override void ExecuteSaveCommand(object obj)
        {
            if (mViewModel.EditingArea == null)
            {
                ShowMessage("Es gibt nichts zu speichern.");
                return;
            }

            if (mViewModel.EditingArea.Plz <= 0)
            {
                ShowMessage("Die Postleitzahl muss größer als 0 sein.");
                return;
            }

            if (mViewModel.EditingArea.Name == "")
            {
                ShowMessage("Bitt einen Namen eingeben.");
                return;
            }

            bool success = false;
            if (mViewModel.EditingArea.Id == 0)
            {
                success = mAreaService.Add(mViewModel.EditingArea);
            }
            else
            {
                success = mAreaService.UpdateArea(mViewModel.EditingArea.Id, mViewModel.EditingArea);
            }

            if (!success)
            {
                ShowMessage("Bitte geben Sie eine eindeutige Postleitzahl ein.");
                return;
            }

            ResetView();
        }
        private void ResetView()
        {
            mViewModel.SelectedArea = null;
            mViewModel.EditingArea = null;
            mViewModel.Areas = new ObservableCollection<Area>(mAreaService.GetAll());
        }
    }
}
