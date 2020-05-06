using IO.Swagger.Api;
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
    /// Логика взаимодействия для LocalBrowser.xaml
    /// </summary>
    public partial class LocalBrowser : Window
    {
        string pID = "";

        public LocalBrowser(string link, string participationId)
        {
            InitializeComponent();

            browser.Navigate(link);
            this.pID = participationId;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var WebinarApiInstance = new WebinApi();
            try
            {
                WebinarApiInstance.GetWebinarDisconnection(Application.Current.Resources["token"].ToString(), pID);
            }
            catch (Exception ex) { }
        }
    }
}
