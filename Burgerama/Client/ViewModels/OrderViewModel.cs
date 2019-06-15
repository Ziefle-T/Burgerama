using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Server.Models;

namespace Client.ViewModels
{
    class OrderViewModel : ActionAreaViewModel
    {
        private ObservableCollection<Order> mOrders;
        public ObservableCollection<Order> Orders
        {
            get { return mOrders;}
            set
            {
                mOrders = value;
                OnPropertyChanged();
            }
        }
        public Order SelectedOrder { get; set; }

        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }

        public bool CanEditOrder
        {
            get { return EditingOrder != null; }
        }

        private Order mEditingOrder;
        public Order EditingOrder
        {
            get { return mEditingOrder;}
            set
            {
                mEditingOrder = value;
                var orderLines = mEditingOrder?.OrderLines;
                if (orderLines != null)
                {
                    OrderLines = new ObservableCollection<OrderLines>(orderLines);
                }
                else
                {
                    OrderLines = new ObservableCollection<OrderLines>();
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(CanEditOrder));
            }
        }

        private ObservableCollection<OrderLines> mOrderLines;
        public ObservableCollection<OrderLines> OrderLines
        {
            get { return mOrderLines;}
            set
            {
                mOrderLines = value;
                OnPropertyChanged();
            }
        }
        public OrderLines SelectedOrderLine { get; set; }

        public ICommand AddArticleCommand { get; set; }
        public ICommand RemoveArticleCommand { get; set; }
    }
}
