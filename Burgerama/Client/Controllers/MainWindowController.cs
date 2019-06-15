using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Client.Framework;
using Client.ViewModels;
using Client.Views;

namespace Client.Controllers
{
    class MainWindowController
    {
        private MainWindowViewModel mMainWindowViewModel;

        public void ExecuteViewSelectionChangedCommand(object obj)
        {
            var selectedSite = obj as string;

            switch (selectedSite)
            {
                case "Start":
                    ShowView<StartViewController, StartViewModel>();
                    break;
                case "Kunden":
                    ShowView<CustomerViewController, CustomerViewModel>();
                    break;
                case "Aufträge":
                    ShowView<OrderViewController, OrderViewModel>();
                    break;
                case "Bestseller":
                    ShowView<BestsellerViewController, BestsellerViewModel>();
                    break;
                case "Umsatzrangliste":
                    ShowView<RevenueListViewController, RevenueListViewModel>();
                    break;
                case "Artikel":
                    ShowView<ArticleViewController, ArticleViewModel>();
                    break;
                case "Fahrer":
                    ShowView<DriverViewController, DriverViewModel>();
                    break;
                case "Liefergebiete":
                    ShowView<AreaViewController, AreaViewModel>();
                    break;
                case "Benutzer":
                    ShowView<UserViewController, UserViewModel>();
                    break;
            }
        }

        private void ShowView<T, Z>() where T : ActionAreaController<Z> where Z : ActionAreaViewModel
        {
            var viewController = App.Container.Resolve<T>();
            var viewModel = viewController.SafeInitialize();

            if (viewModel == null)
            {
                return;
            }

            mMainWindowViewModel.ActiveViewModel = viewModel;

            mMainWindowViewModel.NewCommand = viewModel.NewCommand;
            mMainWindowViewModel.EditCommand = viewModel.EditCommand;
            mMainWindowViewModel.SaveCommand = viewModel.SaveCommand;
            mMainWindowViewModel.DeleteCommand = viewModel.DeleteCommand;
        }

        public void Initialize(bool isAdmin)
        {
            mMainWindowViewModel = new MainWindowViewModel(isAdmin)
            {
                ViewSelectionChangedCommand = new RelayCommand(ExecuteViewSelectionChangedCommand)
            };

            mMainWindowViewModel.SelectedSite = "Start";

            var view = new MainWindow();
            view.DataContext = mMainWindowViewModel;

            view.ShowDialog();
        }
    }
}
