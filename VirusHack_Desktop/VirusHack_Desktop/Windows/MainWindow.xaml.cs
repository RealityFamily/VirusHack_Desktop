using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VirusHack_Desktop.Pages;

namespace VirusHack_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            if (this.Resources["token"] == null)
            {
                Content = new Auth();
            } else
            {
                var apiInstance = new UserApi();
                string token = this.Resources["token"].ToString();
                User result = null;

                try
                {
                    result = apiInstance.GetUserInfo(token);
                } catch (Exception e)
                {
                    Debug.Print("Exception when calling UserApi.GetUserInfo: " + e.Message);
                }
                if (result != null)
                {
                    Content = new Week();
                } else
                {
                    Content = new Auth();
                }
            }
        }
    }
}
