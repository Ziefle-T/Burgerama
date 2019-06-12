using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Framework;
using Client.Server.Models;

namespace Client.ViewModels
{
    class AddArticleViewModel : ViewModelBase
    {
        public ObservableCollection<Article> Articles { get; set; }
        public Article SelectedArticle { get; set; }

        public int Amount { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
