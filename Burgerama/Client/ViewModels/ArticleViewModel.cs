using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Server.Models;

namespace Client.ViewModels
{
    class ArticleViewModel : ActionAreaViewModel
    {
        private ObservableCollection<Article> mArticles;
        public ObservableCollection<Article> Articles
        {
            get { return mArticles;}
            set
            {
                mArticles = value;
                OnPropertyChanged();
            }
        }
        public Article SelectedArticle { get; set; }

        public bool CanEditArticle
        {
            get { return EditingArticle != null; }
        }

        private Article mEditingArticle;
        public Article EditingArticle
        {
            get { return mEditingArticle;}
            set
            {
                mEditingArticle = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanEditArticle));
            }
        }
    }
}
