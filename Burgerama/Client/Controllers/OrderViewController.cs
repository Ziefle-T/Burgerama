﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Client.Framework;
using Client.Server.Models;
using Client.Server.Services;
using Client.ViewModels;

namespace Client.Controllers
{
    class OrderViewController : ActionAreaController<OrderViewModel>
    {
        private IOrderService mOrderService;
        private ICustomerService mCustomerService;
        private IDriverService mDriverService;
        private IOrderLinesService mOrderLinesService;

        public OrderViewController(
            IOrderService orderService,
            ICustomerService customerService,
            IDriverService driverService,
            IOrderLinesService orderLinesService
            ) : base()
        {
            mOrderService = orderService;
            mCustomerService = customerService;
            mDriverService = driverService;
            mOrderLinesService = orderLinesService;
        }

        public override OrderViewModel Initialize()
        {
            var retVal = base.Initialize();

            retVal.Orders = new ObservableCollection<Order>(mOrderService.GetAll());
            retVal.Customers = new ObservableCollection<Customer>(mCustomerService.GetAll());
            retVal.Drivers = new ObservableCollection<Driver>(mDriverService.GetAll());

            retVal.AddArticleCommand = new RelayCommand(ExecuteAddOrderLineCommand);
            retVal.RemoveArticleCommand = new RelayCommand(ExecuteRemoveOrderLineCommand);

            return retVal;
        }

        public override bool CanExecuteDeleteCommand(object obj)
        {
            return mViewModel.SelectedOrder != null;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return mViewModel.SelectedOrder != null;
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
            if (mViewModel.SelectedOrder == null)
            {
                ShowMessage("Nichts zum löschen ausgewählt.");
                return;
            }

            mOrderService.Delete(mViewModel.SelectedOrder.Id);
            ResetView();
        }

        public override void ExecuteEditCommand(object obj)
        {
            mViewModel.EditingOrder = mViewModel.SelectedOrder;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingOrder = new Order()
            {
                Id = 0,
                Description = "",
                OrderNumber = DateTime.Now.ToString("yyyyMMddhhmmss") + mViewModel.Orders.Count,
                Customer = null,
                Driver = null,
                OrderDate = DateTime.Now,
                OrderLines = new OrderLines[0]
            };
        }

        public override void ExecuteSaveCommand(object obj)
        {
            if (mViewModel.EditingOrder == null)
            {
                ShowMessage("Es gibt nichts zu speichern.");
                return;
            }

            if (mViewModel.EditingOrder.Id == 0)
            {
                mOrderService.Add(mViewModel.EditingOrder);
            }
            else
            {
                mOrderService.UpdateOrder(mViewModel.EditingOrder.Id, mViewModel.EditingOrder);
            }

            ResetView();
        }

        public void ExecuteAddOrderLineCommand(object obj)
        {
            try
            {
                if (mViewModel.EditingOrder == null)
                {
                    ShowMessage("Keine Bestellung ausgewählt.");
                    return;
                }

                AddArticleViewController addArticleViewController = App.Container.Resolve<AddArticleViewController>();
                var addedOrderLines = addArticleViewController.CreateOrderLines();

                if (addedOrderLines != null
                    && mViewModel.EditingOrder != null)
                {
                    var editingOrder = mViewModel.EditingOrder;
                    var list = editingOrder.OrderLines.ToList();
                    list.Add(addedOrderLines);
                    editingOrder.OrderLines = list.ToArray();
                    mViewModel.EditingOrder = editingOrder;
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
            }
        }

        public void ExecuteRemoveOrderLineCommand(object obj)
        {
            try
            {
                var editingOrder = mViewModel.EditingOrder;
                if (editingOrder == null ||
                    mViewModel.SelectedOrderLine == null)
                {
                    ShowMessage("Kein Element zum löschen ausgewählt.");
                    return;
                }
                
                mOrderLinesService.Delete(mViewModel.SelectedOrderLine.Id);
                var list = editingOrder.OrderLines.ToList();
                list.Remove(mViewModel.SelectedOrderLine);
                editingOrder.OrderLines = list.ToArray();
                mViewModel.EditingOrder = editingOrder;

            }
            catch (Exception e)
            {
                ShowMessage(e.ToString());
            }
        }
        
        private void ResetView()
        {
            mViewModel.SelectedOrder = null;
            mViewModel.EditingOrder = null;
            mViewModel.Orders = new ObservableCollection<Order>(mOrderService.GetAll());
        }
    }
}
