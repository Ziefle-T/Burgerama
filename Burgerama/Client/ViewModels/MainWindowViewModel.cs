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

        private string mTitle;
        public string Title
        {
            get { return mTitle; }
            set
            {
                mTitle = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> mSites;
        public ObservableCollection<string> Sites
        {
            get { return mSites;}
            set
            {
                mSites = value;
                OnPropertyChanged();
            }
        }

        private string mSelectedSite;
        public string SelectedSite {
            get { return mSelectedSite; }
            set
            {
                mSelectedAdminSite = "";
                var temp = AdminSites;
                AdminSites = null;
                AdminSites = temp;
                ViewSelectionChangedCommand.Execute(value);
                SelectedSitePropertyChanged();

                mSelectedSite = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> mAdminSites;
        public ObservableCollection<string> AdminSites
        {
            get { return mAdminSites; }
            set
            {
                mAdminSites = value;
                OnPropertyChanged();
            }
        }
        private string mSelectedAdminSite;
        public string SelectedAdminSite
        {
            get { return mSelectedAdminSite; }
            set
            {
                mSelectedSite = "";
                var temp = Sites;
                Sites = null;
                Sites = temp;
                ViewSelectionChangedCommand.Execute(value);
                SelectedSitePropertyChanged();

                mSelectedAdminSite = value;
                OnPropertyChanged();
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
            OnPropertyChanged(nameof(NewCommand));
            OnPropertyChanged(nameof(EditCommand));
            OnPropertyChanged(nameof(SaveCommand));
            OnPropertyChanged(nameof(DeleteCommand));
        }
    }
}
