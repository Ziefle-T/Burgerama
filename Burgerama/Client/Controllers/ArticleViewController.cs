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

namespace Client.Controllers
{
    class ArticleViewController : ActionAreaController<ArticleViewModel>
    {
        private IArticleService mArticleService;

        public ArticleViewController(IArticleService articleService) : base()
        {
            mArticleService = articleService;
            mUpdateConflictMessage = "Bitte geben Sie eine eindeutige Artikelnummer ein.";
        }

        public override ArticleViewModel Initialize()
        {
            var retVal = base.Initialize();

            retVal.Articles = new ObservableCollection<Article>(mArticleService.GetAll());

            return retVal;
        }

        public override bool CanExecuteDeleteCommand(object obj)
        {
            return mViewModel.SelectedArticle != null;
        }
        public override bool CanExecuteEditCommand(object obj)
        {
            return mViewModel.SelectedArticle != null;
        }
        public override bool CanExecuteNewCommand(object obj)
        {
            return true;
        }
        public override bool CanExecuteSaveCommand(object obj)
        {
            return mViewModel.EditingArticle != null;
        }

        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedArticle == null)
            {
                ShowMessage("Bitte einen Artikel zum löschen auswählen.");
                return;
            }

            if (mArticleService.Delete(mViewModel.SelectedArticle.Id))
            {
                ResetView();  
            }
            else
            {
                ShowMessage("Der Artikel konnte nicht glöscht werden.\n" +
                            "Bitte löschen Sie zuerst alle mit dem Artikel verbundenen Bestellungen.");
            }
        }

        public override void ExecuteEditCommand(object obj)
        {
            if (mViewModel.SelectedArticle == null)
            {
                ShowMessage("Bitte einen Artikel zum bearbeiten auswählen.");
                return;
            }

            mViewModel.EditingArticle = mViewModel.SelectedArticle;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingArticle = new Article()
            {
                Id = 0,
                ArticleNumber = "",
                Description = "",
                Price = 0,
                Name = ""
            };
        }

        public override void ExecuteSaveCommand(object obj)
        {
            if (mViewModel.EditingArticle == null)
            {
                ShowMessage("Es gibt nichts zu speichern.");
                return;
            }

            if (mViewModel.EditingArticle.ArticleNumber == "")
            {
                ShowMessage("Bitte geben Sie eine Artikelnummer ein.");
                return;
            }

            if (mViewModel.EditingArticle.Name == "")
            {
                ShowMessage("Bitte geben Sie einen Namen ein.");
                return;
            }

            if (mViewModel.EditingArticle.Price <= 0)
            {
                ShowMessage("Der Preis muss größer als 0€ sein.");
                return;
            }

            int updateResult = 1;
            if (mViewModel.EditingArticle.Id == 0)
            {
                updateResult = mArticleService.Add(mViewModel.EditingArticle) ? 0 : 1;
            }
            else
            {
                updateResult = mArticleService.UpdateArticle(mViewModel.EditingArticle.Id, mViewModel.EditingArticle);
            }

            HandleUpdateResult(updateResult);
        }

        override protected void ResetView()
        {
            mViewModel.SelectedArticle = null;
            mViewModel.EditingArticle = null;
            mViewModel.Articles = new ObservableCollection<Article>(mArticleService.GetAll());
        }
    }
}
