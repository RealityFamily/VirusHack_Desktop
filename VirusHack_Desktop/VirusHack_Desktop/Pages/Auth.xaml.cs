using IO.Swagger.Api;
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

            LoginText.GotFocus += RemoveTextLogin;
            LoginText.LostFocus += AddTextLogin;

            PasswordText.GotFocus += RemoveTextPass;
            PasswordText.LostFocus += AddTextPass;

            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Error.Visibility = Visibility.Collapsed;

            var ApiInstance = new UserApi();

            Login l = new Login(LoginText.Text, PasswordText.Text);

            string token = null;

            try
            {
                token = ApiInstance.LoginUser(l).Token;
            } catch(Exception)
            {
                Error.Visibility = Visibility.Visible;
            }

            if (token != null) {
                Application.Current.Resources["token"] = token;
                ((NavigationWindow)Application.Current.MainWindow).Content = new Week(); 
            }
        }

        
        
        public void RemoveTextLogin(object sender, EventArgs e)
        {
            LoginText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66ffffff"));
            LoginError.Visibility = Visibility.Collapsed;

            if (LoginText.Text == "Ваша почта с доменном @mirea.ru или @edu.mirea.ru")
            {
                LoginText.Text = "";
            }
        }

        public void AddTextLogin(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginText.Text))
                LoginText.Text = "Ваша почта с доменном @mirea.ru или @edu.mirea.ru";
            if (!LoginText.Text.Contains("@mirea.ru") && !LoginText.Text.Contains("@edu.mirea.ru"))
            {
                LoginError.Visibility = Visibility.Visible;
            }
        }

        public void RemoveTextPass(object sender, EventArgs e)
        {
            PasswordText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66ffffff"));

            if (PasswordText.Text == "Ваш пароль от системы ЦДО")
            {
                PasswordText.Text = "";
            }
        }

        public void AddTextPass(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordText.Text))
                PasswordText.Text = "Ваш пароль от системы ЦДО";
        }
    }
}
