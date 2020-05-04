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
using VirusHack_Desktop.Pages;

namespace VirusHack_Desktop
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();

            Login.GotFocus += RemoveTextLogin;
            Login.LostFocus += AddTextLogin;

            Password.GotFocus += RemoveTextPass;
            Password.LostFocus += AddTextPass;

            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((NavigationWindow)Application.Current.MainWindow).Content = new Week();
        }

        
        
        public void RemoveTextLogin(object sender, EventArgs e)
        {
            Login.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66ffffff"));
            LoginError.Visibility = Visibility.Collapsed;

            if (Login.Text == "Ваша почта с доменном @mirea.ru или @edu.mirea.ru")
            {
                Login.Text = "";
            }
        }

        public void AddTextLogin(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login.Text))
                Login.Text = "Ваша почта с доменном @mirea.ru или @edu.mirea.ru";
            if (!Login.Text.Contains("@mirea.ru") && !Login.Text.Contains("@edu.mirea.ru"))
            {
                LoginError.Visibility = Visibility.Visible;
            }
        }

        public void RemoveTextPass(object sender, EventArgs e)
        {
            Password.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66ffffff"));

            if (Password.Text == "Ваш пароль от системы ЦДО")
            {
                Password.Text = "";
            }
        }

        public void AddTextPass(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password.Text))
                Password.Text = "Ваш пароль от системы ЦДО";
        }
    }
}
