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
        private ObservableCollection<Area> mAreas;

        public ObservableCollection<Area> Areas
        {
            get { return mAreas; }
            set
            {
                mAreas = value;
                OnPropertyChanged();
            }
        }

        public Area SelectedArea { get; set; }
        private ObservableCollection<Driver> mDrivers;
        public ObservableCollection<Driver> Drivers
        {
            get { return mDrivers; }
            set
            {
                mDrivers = value;
                OnPropertyChanged();
            }
        }
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
                var tempAreas = Areas;
                Areas = null;
                Areas = tempAreas;
            }
        }
        public ICommand AddDriverCommand { get; set; }
        public ICommand RemoveDriverCommand { get; set; }
    }
}
