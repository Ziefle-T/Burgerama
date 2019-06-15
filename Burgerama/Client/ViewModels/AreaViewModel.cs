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
        public ObservableCollection<Area> Areas { get; set; }
        public Area SelectedArea { get; set; }
        public Area EditingArea;
        public ICommand AddAreaCommand { get; set; }
        public ICommand RemoveAreaCommand{ get; set; }
    }
}
