using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.Views
{
    public class SubmoduleSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var contentControl = (container as FrameworkElement);

            if (item is StartViewModel)
            {
                return contentControl.FindResource("Start") as DataTemplate;
            }

            if (item is CustomerViewModel)
            {
                return contentControl.FindResource("Kunden") as DataTemplate;
            }

            if (item is OrderViewModel)
            {
                return contentControl.FindResource("Aufträge") as DataTemplate;
            }

            if (item is BestsellerViewModel)
            {
                return contentControl.FindResource("Bestseller") as DataTemplate;
            }

            if (item is RevenueListViewModel)
            {
                return contentControl.FindResource("Umsatzrangliste") as DataTemplate;
            }

            if (item is ArticleViewModel)
            {
                return contentControl.FindResource("Artikel") as DataTemplate;
            }

            if (item is DriverViewModel)
            {
                return contentControl.FindResource("Fahrer") as DataTemplate;
            }

            if (item is AreaViewModel)
            {
                return contentControl.FindResource("Liefergebiete") as DataTemplate;
            }

            if (item is UserViewModel)
            {
                return contentControl.FindResource("Benutzer") as DataTemplate;
            }

            return null;
        }
    }
}
