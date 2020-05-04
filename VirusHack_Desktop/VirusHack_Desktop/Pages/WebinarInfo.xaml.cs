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
using VirusHack_Desktop.UserModels;

namespace VirusHack_Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для WebinarInfo.xaml
    /// </summary>
    public partial class WebinarInfo : Page
    {
        public WebinarInfo(Webinar webinar)
        {
            InitializeComponent();

            foreach (ModelFile file in webinar.Files)
            {
                FileLine fl = new FileLine(file.Name, file.Link);
                FilesList.Children.Add(fl);
            }
        }
    }
}
