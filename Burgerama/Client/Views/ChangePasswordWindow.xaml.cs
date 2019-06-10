using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaktionslogik für ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var sendingElement = sender as PasswordBox;
            switch (sendingElement.Name)
            {
                case "passwordBox":
                    passwordLabel.Visibility = sendingElement.Password == "" ? Visibility.Visible : Visibility.Hidden;
                    break;
                case "newPasswordBox":
                    newPasswordLabel.Visibility = sendingElement.Password == "" ? Visibility.Visible : Visibility.Hidden;
                    break;
                case "newPasswordWBox":
                    newPasswordWLabel.Visibility = sendingElement.Password == "" ? Visibility.Visible : Visibility.Hidden;
                    break;
            }
        }
    }
}
