using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    public class ActionAreaViewModel : ViewModelBase
    {
        public ICommand NewCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public virtual string Title { get; }
    }
}
