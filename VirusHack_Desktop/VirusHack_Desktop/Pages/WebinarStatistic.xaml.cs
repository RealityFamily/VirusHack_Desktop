﻿using IO.Swagger.Model;
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
    /// Логика взаимодействия для WebinarStatistic.xaml
    /// </summary>
    public partial class WebinarStatistic : Page
    {
        Webinar webin = new Webinar();

        public WebinarStatistic(Webinar webinar)
        {
            InitializeComponent();

            this.webin = webinar;
            contentContainer.Navigate(new Statistics(webinar));
        }

        private void StatisticButton_Click(object sender, RoutedEventArgs e)
        {
            contentContainer.Navigate(new Statistics(webin));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((NavigationWindow)Application.Current.MainWindow).CanGoBack)
            {
                ((NavigationWindow)Application.Current.MainWindow).GoBack();
            }
        }
    }
}
