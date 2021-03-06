﻿using System;
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
    class CustomerViewController : ActionAreaController<CustomerViewModel>
    {
        private ICustomerService mCustomerService;

        public CustomerViewController(ICustomerService customerService)
        {
            mCustomerService = customerService;
            mUpdateConflictMessage = "Die Telefonnummer muss eindeutig sein.";
        }

        public override CustomerViewModel Initialize()
        {
            var retVal = base.Initialize();

            retVal.Customers = new ObservableCollection<Customer>(mCustomerService.GetAll());

            return retVal;
        }

        public override bool CanExecuteDeleteCommand(object obj)
        {
            return mViewModel.SelectedCustomer != null;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return mViewModel.SelectedCustomer != null;
        }
        public override bool CanExecuteNewCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteSaveCommand(object obj)
        {
            return mViewModel.EditingCustomer != null;
        }


        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedCustomer == null)
            {
                ShowMessage("Bitte Kunde zum löschen auswählen.");
                return;
            }

            if (mCustomerService.Delete(mViewModel.SelectedCustomer.Id))
            {
                ResetView();
            }
            else
            {
                ShowMessage("Der Kunde konnte nicht gelöscht werden.\n" +
                            "Bitte löschen Sie zuerst alle mit dem Kunden verbundenen Bestellungen.");   
            }
        }

        public override void ExecuteEditCommand(object obj)
        {
            mViewModel.EditingCustomer = mViewModel.SelectedCustomer;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingCustomer = new Customer()
            {
                Id = 0,
                Phone = "",
                FirstName = "",
                LastName = "",
                Street = "",
                StreetNumber = "",
                City = "",
                Plz = 0
            };
        }

        public override void ExecuteSaveCommand(object obj)
        {
            if (mViewModel.EditingCustomer == null)
            {
                ShowMessage("Es gibt nichts zu speichern.");
                return;
            }

            if (mViewModel.EditingCustomer.Phone == "")
            {
                ShowMessage("Bitte geben Sie eine Telefonnummer ein.");
                return;
            }

            if (mViewModel.EditingCustomer.LastName == "")
            {
                ShowMessage("Bitte geben Sie einen Nachnamen ein.");
                return;
            }
            
            if (mViewModel.EditingCustomer.Street == "")
            {
                ShowMessage("Bitte geben Sie eine Straße ein.");
                return;
            }

            if (mViewModel.EditingCustomer.StreetNumber == "")
            {
                ShowMessage("Bitte geben Sie eine Straßennummer ein.");
                return;
            }

            if (mViewModel.EditingCustomer.Plz <= 0)
            {
                ShowMessage("Die Postleitzahl muss größer als 0 sein.");
                return;
            }

            if (mViewModel.EditingCustomer.City == "")
            {
                ShowMessage("Bitte geben Sie einen Ort ein.");
                return;
            }

            int updateResult = 1;
            if (mViewModel.EditingCustomer.Id == 0)
            {
                updateResult = mCustomerService.Add(mViewModel.EditingCustomer) ? 0 : 1;
            }
            else
            {
                updateResult = mCustomerService.UpdateCustomer(mViewModel.EditingCustomer);
            }

            HandleUpdateResult(updateResult); 
        }

        override protected void ResetView()
        {
            mViewModel.SelectedCustomer = null;
            mViewModel.EditingCustomer = null;
            mViewModel.Customers = new ObservableCollection<Customer>(mCustomerService.GetAll());
        }
    }
}
