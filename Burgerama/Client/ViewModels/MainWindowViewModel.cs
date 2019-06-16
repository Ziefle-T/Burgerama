using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Framework;
using Client.Views;

namespace Client.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand ViewSelectionChangedCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<string> Sites { get; set; }
        private string mSelectedSite;
        public string SelectedSite {
            get { return mSelectedSite; }
            set
            {
                mSelectedSite = value;
                mSelectedAdminSite = "";
                ViewSelectionChangedCommand.Execute(value);
                SelectedSitePropertyChanged();
            }
        }

        public ObservableCollection<string> AdminSites { get; set; }
        private string mSelectedAdminSite;
        public string SelectedAdminSite
        {
            get { return mSelectedAdminSite; }
            set
            {
                mSelectedAdminSite = value;
                mSelectedSite = "";
                ViewSelectionChangedCommand.Execute(value);
                SelectedSitePropertyChanged();
            }
        }
        
        public Visibility ShowAdmin { get; set; }

        private ViewModelBase mActiveViewModel;
        public ViewModelBase ActiveViewModel
        {
            get { return mActiveViewModel;}
            set
            {
                if (mActiveViewModel == value)
                    return;

                mActiveViewModel = value;
                OnPropertyChanged(nameof(ActiveViewModel));
            }
        }

        public MainWindowViewModel(bool isAdmin)
        {
            Sites = new ObservableCollection<string>()
            {
                "Start",
                "Kunden",
                "Aufträge",
                "Bestseller",
                "Umsatzrangliste"
            };

            if (isAdmin)
            {
                AdminSites = new ObservableCollection<string>()
                {
                    "Artikel",
                    "Fahrer",
                    "Liefergebiete",
                    "Benutzer"
                };
            }
            else
            {
                AdminSites = new ObservableCollection<string>();
            }

            ShowAdmin = isAdmin ? Visibility.Visible : Visibility.Hidden;
        }

        private void SelectedSitePropertyChanged()
        {
            OnPropertyChanged(nameof(mSelectedSite));
            OnPropertyChanged(nameof(mSelectedAdminSite));
            OnPropertyChanged(nameof(NewCommand));
            OnPropertyChanged(nameof(EditCommand));
            OnPropertyChanged(nameof(SaveCommand));
            OnPropertyChanged(nameof(DeleteCommand));
        }
    }
}
