using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using Client.Server.Models;

namespace Client.ViewModels
{
    class CustomerViewModel : ActionAreaViewModel
    {
        private ObservableCollection<Customer> mCustomers;
        public ObservableCollection<Customer> Customers
        {
            get { return mCustomers;}
            set
            {
                mCustomers = value;
                OnPropertyChanged();
            }
        }
        public Customer SelectedCustomer { get; set; }

        public bool CanEditCustomer
        {
            get { return EditingCustomer != null; }
        }

        private Customer mEditingCustomer;
        public Customer EditingCustomer
        {
            get { return mEditingCustomer; }
            set
            {
                mEditingCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanEditCustomer));
            }
        }
    }
}
