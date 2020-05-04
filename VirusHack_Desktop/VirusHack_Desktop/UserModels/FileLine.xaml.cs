using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class FileLine : UserControl
    {
        string fileLink;

        public FileLine(string fileName, string fileLink)
        {
            InitializeComponent();

            FileName.Text = fileName;
            this.fileLink = fileLink;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(fileLink) { UseShellExecute = true });
        }
    }
}
