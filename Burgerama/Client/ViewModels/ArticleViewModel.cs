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
        public ObservableCollection<Article> Articles { get; set; }
        public Article SelectedArticle { get; set; }
        public Article EditingArticle;
        public ICommand AddArticleCommand { get; set; }
        public ICommand RemoveArticleCommand { get; set; }
    }
}
