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

        private Customer mEditingCustomer;
        public Customer EditingCustomer
        {
            get { return mEditingCustomer; }
            set
            {
                mEditingCustomer = value;
                if (mEditingCustomer != null)
                {
                    EditingCustomerHeader = mEditingCustomer.FirstName ?? "";
                    EditingCustomerHeader += " " + mEditingCustomer.LastName ?? "";
                    if (mEditingCustomer.Phone != null)
                        EditingCustomerHeader += " (" + mEditingCustomer.Phone + ")";
                }
                else
                {
                    EditingCustomerHeader = "";
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(EditingCustomerHeader));
            }
        }
        public string EditingCustomerHeader { get; set; }
    }
}
