using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    class MessageViewController
    {
        private MessageView mView;

        public void ExecuteOkCommand(object obj)
        {
            mView.Close();
        }

        public void Initialize(string message)
        {
            var model = new MessageViewModel()
            {
                Message = message,
                OkCommand = new RelayCommand(ExecuteOkCommand)
            };

            mView = new MessageView();
            mView.DataContext = model;

            mView.ShowDialog();
        }
    }
}
