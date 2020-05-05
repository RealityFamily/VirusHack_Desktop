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
using System.Windows.Shapes;

namespace VirusHack_Desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        string pID = "";

        public BrowserWindow(string link, string participationId)
        {
            InitializeComponent();

            this.pID = participationId;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var WebinarApiInstance = new WebinApi();
            try
            {
                WebinarApiInstance.GetWebinarDisconnection(Application.Current.Resources["token"].ToString(), pID);
            } catch (Exception ex) { }
        }
    }
}
