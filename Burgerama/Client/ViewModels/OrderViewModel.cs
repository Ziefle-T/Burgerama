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
        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder { get; set; }

        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }

        public Order EditingOrder;

        public OrderLines SelectedOrderLine { get; set; }

        public ICommand AddArticleCommand { get; set; }
        public ICommand RemoveArticleCommand { get; set; }
    }
}
