using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class BaseController
    {
        protected void ShowMessage(string message)
        {
            MessageViewController messageViewController = new MessageViewController();
            messageViewController.Initialize(message);
        }
    }
}
