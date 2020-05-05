using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirusHack_Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        public UserInfo(User user)
        {
            InitializeComponent();

            Name.Text = user.LastName + " " + user.FirstName;
            if (user.UserStatus == UserStatus.Student)
            {
                Group.Text = user.Group;
            } else
            {
                Group.Visibility = Visibility.Collapsed;
                GroupSeparator.Visibility = Visibility.Collapsed;
            }
            Email.Text = user.Email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((NavigationWindow)Application.Current.MainWindow).Navigate(new Auth());
        }
    }
}
