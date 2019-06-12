using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    class MessageViewModel : ViewModelBase
    {
        public string Message { get; set; }
        public ICommand OkCommand { get; set; }
    }
}
