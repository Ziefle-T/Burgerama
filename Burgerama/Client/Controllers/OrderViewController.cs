using System;
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
            return mViewModel.EditingOrder != null;
        }

        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedOrder == null)
            {
                ShowMessage("Nichts zum löschen ausgewählt.");
                return;
            }

            if (mOrderService.Delete(mViewModel.SelectedOrder.Id))
            {
                ResetView();
            }
            else
            {
                ShowMessage("Die Bestellung konnte nicht gelöscht werden, oder wurde bereits gelöscht.");   
            }
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

            if (mViewModel.EditingOrder.OrderDate == null)
            {
                ShowMessage("Bitte geben Sie ein Bestelldatum an.");
                return;
            }

            if (mViewModel.EditingOrder.Driver == null)
            {
                ShowMessage("Bitte geben Sie einen Fahrer an.");
                return;
            }

            if (mViewModel.EditingOrder.Customer == null)
            {
                ShowMessage("Bitte geben Sie einen Kunden an.");
                return;
            }

            bool success = false;
            if (mViewModel.EditingOrder.Id == 0)
            {
                success = mOrderService.Add(mViewModel.EditingOrder);
            }
            else
            {
                success = mOrderService.UpdateOrder(mViewModel.EditingOrder.Id, mViewModel.EditingOrder);
            }

            if (!success)
            {
                ShowMessage("Die Bestellung konnte nicht gespeichert werden.");
                return;
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

                    int maxpos = 0;
                    foreach (var orderLine in list)
                    {
                        maxpos = orderLine.Position >= maxpos ? orderLine.Position + 1 : maxpos;
                        if (orderLine.Article.Id == addedOrderLines.Article.Id)
                        {
                            orderLine.Amount += addedOrderLines.Amount;
                            editingOrder.OrderLines = list.ToArray();
                            mViewModel.EditingOrder = editingOrder;
                            return;
                        }
                    }

                    addedOrderLines.Position = maxpos;

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

                //if (mViewModel.SelectedOrderLine.Id == 0) // ||
                //    //mOrderLinesService.Delete(mViewModel.SelectedOrderLine.Id))
                //{
                    var list = editingOrder.OrderLines.ToList();
                    list.Remove(mViewModel.SelectedOrderLine);
                    editingOrder.OrderLines = list.ToArray();
                    mViewModel.EditingOrder = editingOrder;
                //}
                //else
                //{
                //    ShowMessage("Der Artikel konnte nicht entfernt werden.");   
                //}
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
