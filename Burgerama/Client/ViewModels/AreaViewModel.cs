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
    class AreaViewModel : ActionAreaViewModel
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
        private Area mEditingArea;
        public Area EditingArea
        {
            get { return mEditingArea; }
            set
            {
                mEditingArea = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddAreaCommand { get; set; }
        public ICommand RemoveAreaCommand{ get; set; }
    }
}
