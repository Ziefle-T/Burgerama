using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using Client.ViewModels;

namespace Client.Controllers
{
    class CustomerViewController : ActionAreaController<CustomerViewModel>
    {
        public override bool CanExecuteDeleteCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteNewCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteSaveCommand(object obj)
        {
            return true;
        }


        public override void ExecuteDeleteCommand(object obj)
        {
            
        }
        public override void ExecuteEditCommand(object obj)
        {
            
        }
        public override void ExecuteNewCommand(object obj)
        {
            
        }
        public override void ExecuteSaveCommand(object obj)
        {
            
        }
    }
}
