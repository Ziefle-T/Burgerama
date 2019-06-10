using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Framework;

namespace Client.ViewModels
{
    class ChangepasswordViewModel : ViewModelBase
    {
        public ICommand ChangeCommand { get; set; }

        public Visibility ShowPasswordLabel { get; set; }
        public Visibility ShowNewPasswordLabel { get; set; }
        public Visibility ShowNewPasswordWLabel { get; set; }
    }
}
