using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Framework;
using Client.Server.Models;
using Client.Server.Services;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    class AddArticleViewController : BaseController
    {
        private IArticleService mArticleService;

        private AddArticleViewModel mAddArticleViewModel;
        private AddArticleView mAddArticleView;

        public AddArticleViewController(IArticleService articleService)
        {
            mArticleService = articleService;
        }

        public void ExecuteAddCommand(object obj)
        {
            if (mAddArticleViewModel.SelectedArticle == null)
            {
                ShowMessage("Bitte zuerst einen Artikel auswählen.");
                return;
            }

            if (mAddArticleViewModel.Amount == 0)
            {
                ShowMessage("Bitte mehr als 0 Artikel hinzufügen.");
                return;
            }

            mAddArticleView.DialogResult = true;
            mAddArticleView.Close();
        }

        public void ExecuteCancelCommand(object obj)
        {
            mAddArticleView.DialogResult = false;
            mAddArticleView.Close();
        }

        public OrderLines CreateOrderLines()
        {
            mAddArticleViewModel = new AddArticleViewModel()
            {
                Articles = new ObservableCollection<Article>(mArticleService.GetAll()),
                Amount = 0,
                AddCommand = new RelayCommand(ExecuteAddCommand),
                CancelCommand = new RelayCommand(ExecuteCancelCommand)
            };

            mAddArticleView = new AddArticleView();
            mAddArticleView.DataContext = mAddArticleViewModel;

            if (mAddArticleView.ShowDialog() ?? false)
            {
                if (mAddArticleViewModel.SelectedArticle == null)
                {
                    ShowMessage("Etwas ist schief gelaufen.");
                    return null;
                }

                return new OrderLines()
                {
                    Amount = mAddArticleViewModel.Amount,
                    Article = mAddArticleViewModel.SelectedArticle
                };
            }

            return null;
        }
    }
}
