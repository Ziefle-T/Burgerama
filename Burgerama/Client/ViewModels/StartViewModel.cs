using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    class StartViewModel : ActionAreaViewModel
    {
        public ICommand ChangePasswordCommand { get; set; }
    }
}
