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

        public ArticleViewController(
            IArticleService articleService

        ) : base()
        {
            mArticleService = articleService;
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
            return true;
        }

        public override void ExecuteDeleteCommand(object obj)
        {
            if (mViewModel.SelectedArticle == null)
            {
                ShowMessage("Nichts zum löschen ausgewählt.");
                return;
            }

            mArticleService.Delete(mViewModel.SelectedArticle.ArticleNumber);
            ResetView();
        }

        public override void ExecuteEditCommand(object obj)
        {
            mViewModel.EditingArticle = mViewModel.SelectedArticle;
        }

        public override void ExecuteNewCommand(object obj)
        {
            mViewModel.EditingArticle = new Article()
            {
                ArticleNumber = 0,
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

            if (mViewModel.EditingArticle.ArticleNumber == 0)
            {
                mArticleService.Add(mViewModel.EditingArticle);
            }
            else
            {
                mArticleService.UpdateArticle(mViewModel.EditingArticle.ArticleNumber, mViewModel.EditingArticle);
            }

            ResetView();
        }
        private void ResetView()
        {
            mViewModel.SelectedArticle = null;
            mViewModel.EditingArticle = null;
            mViewModel.Articles = new ObservableCollection<Article>(mArticleService.GetAll());
        }
    }
}
