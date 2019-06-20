using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ViewModels
{
    class RevenueListViewModel : ActionAreaViewModel
    {
        public override string Title
        {
            get { return "Burgerama - Umsatzrangliste"; }
        }

        public ObservableCollection<AreaBestseller> AreaBestsellers { get; set; }
    }
}
