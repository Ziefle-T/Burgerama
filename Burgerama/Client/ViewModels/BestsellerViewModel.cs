using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ViewModels
{
    class BestsellerViewModel : ActionAreaViewModel
    {
        public ObservableCollection<Bestseller> Bestsellers { get; set; }
    }
}
