using Client.Server.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    class DriverViewModel : ActionAreaViewModel
    {
        public ObservableCollection<Area> Areas { get; set; }
        public Area SelectedArea { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
        public Driver SelectedDriver { get; set; }
        private Driver mEditingDriver;

        public Driver EditingDriver
        {
            get { return mEditingDriver; }
            set
            {
                mEditingDriver = value;
                foreach (var area in Areas)
                {
                    area.Driver = mEditingDriver;
                }
                OnPropertyChanged();
            }
        }
        public ICommand AddDriverCommand { get; set; }
        public ICommand RemoveDriverCommand { get; set; }
    }
}
