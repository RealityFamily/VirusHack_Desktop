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
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public Statistics(Webinar webinar)
        {
            InitializeComponent();

            if (webinar.EndTime.HasValue) {
                EndTime.Text = webinar.EndTime.Value.Hour + "час " + webinar.EndTime.Value.Minute + "мин ";
            }

            if (webinar.Present != null) {
                PresentNum.Text = webinar.Present.Count.ToString();
            }

            int AllSum = 0;
            foreach (Group group in webinar.Groups)
            {
                AllSum += group.Students.Count;
            }
            AllNum.Text = AllSum.ToString();

            if (webinar.Present != null) {
                foreach (Group group in webinar.Groups)
                {
                    TextBlock tb = new TextBlock() {
                        FontSize = 24,
                        Margin = new Thickness(10),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                        Text = group.Name
                    };
                    StudentsContainer.Children.Add(tb);

                    foreach (User student in group.Students)
                    {
                        FontWeight fw = FontWeights.Normal;
                        if (webinar.Present.Contains(student))
                        {
                            fw = FontWeights.Medium;
                        }
                        TextBlock tb1 = new TextBlock()
                        {
                            FontSize = 24,
                            Margin = new Thickness(10),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                            FontWeight = fw,
                            Text = group.Name
                        };
                        StudentsContainer.Children.Add(tb1);
                    }

                    Separator sep = new Separator() {
                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2B2B2B")),
                        Margin = new Thickness(15)
                    };
                    StudentsContainer.Children.Add(sep);
                }
            }
        }
    }
}
