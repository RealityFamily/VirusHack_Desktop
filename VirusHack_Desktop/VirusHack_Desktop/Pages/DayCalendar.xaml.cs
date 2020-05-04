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
    /// Логика взаимодействия для DayCalendar.xaml
    /// </summary>
    public partial class DayCalendar : Page
    {
        public DayCalendar()
        {
            InitializeComponent();

            for(int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    LessonsContainer.RowDefinitions.Add(new RowDefinition()
                    {
                        MinHeight = 20
                    });
                    Border b = new Border();
                    Grid.SetRow(b, j + i * 12);
                    Grid.SetColumn(b, 1);
                    b.BorderThickness = new Thickness(0, 0, 0, 1);
                    b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#65A6D1"));
                    LessonsContainer.Children.Add(b);
                }
                // heh
                Border b1 = new Border();
                Grid.SetRow(b1, i * 12);
                Grid.SetRowSpan(b1, 12);
                Grid.SetColumn(b1, 0);
                b1.BorderThickness = new Thickness(0, 0, 0, 1);
                b1.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#65A6D1"));
                b1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8065A6D1"));

                string time = "";
                switch (i)
                {
                    case 0:
                        time = "9:00";
                        break;
                    case 1:
                        time = "10:00";
                        break;
                    case 2:
                        time = "11:00";
                        break;
                    case 3:
                        time = "12:00";
                        break;
                    case 4:
                        time = "13:00";
                        break;
                    case 5:
                        time = "14:00";
                        break;
                    case 6:
                        time = "15:00";
                        break;
                    case 7:
                        time = "16:00";
                        break;
                    case 8:
                        time = "17:00";
                        break;
                    case 9:
                        time = "18:00";
                        break;
                    case 10:
                        time = "19:00";
                        break;
                    case 11:
                        time = "20:00";
                        break;
                    case 12:
                        time = "21:00";
                        break;
                }

                b1.Child = new TextBlock()
                {
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#777777")),
                    Text = time
                };
                LessonsContainer.Children.Add(b1);
            }
        }
    }
}
