﻿using Client.Server.Models;
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
        public Driver EditingDriver;
        public ICommand AddDriverCommand { get; set; }
        public ICommand RemoveDriverCommand { get; set; }
    }
}
