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
    /// Логика взаимодействия для WeekCalendar.xaml
    /// </summary>
    public partial class WeekCalendar : Page
    {
        public WeekCalendar(List<Webinar> webinars, DateTime dateInWeek)
        {
            InitializeComponent();

            switch (dateInWeek.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dateInWeek = dateInWeek.AddDays(1);
                    MonDate.Text = dateInWeek.AddDays(0).ToString("dd.MM");
                    TuesDate.Text = dateInWeek.AddDays(1).ToString("dd.MM");
                    WedDate.Text = dateInWeek.AddDays(2).ToString("dd.MM");
                    ThurDate.Text = dateInWeek.AddDays(3).ToString("dd.MM");
                    FridDate.Text = dateInWeek.AddDays(4).ToString("dd.MM");
                    SatDate.Text = dateInWeek.AddDays(5).ToString("dd.MM");
                    break;
                case DayOfWeek.Monday:
                    MonDate.Text = dateInWeek.AddDays(0).ToString("dd.MM");
                    TuesDate.Text = dateInWeek.AddDays(1).ToString("dd.MM");
                    WedDate.Text = dateInWeek.AddDays(2).ToString("dd.MM");
                    ThurDate.Text = dateInWeek.AddDays(3).ToString("dd.MM");
                    FridDate.Text = dateInWeek.AddDays(4).ToString("dd.MM");
                    SatDate.Text = dateInWeek.AddDays(5).ToString("dd.MM");
                    break;
                case DayOfWeek.Tuesday:
                    MonDate.Text = dateInWeek.AddDays(-1).ToString("dd.MM");
                    TuesDate.Text = dateInWeek.AddDays(0).ToString("dd.MM");
                    WedDate.Text = dateInWeek.AddDays(1).ToString("dd.MM");
                    ThurDate.Text = dateInWeek.AddDays(2).ToString("dd.MM");
                    FridDate.Text = dateInWeek.AddDays(3).ToString("dd.MM");
                    SatDate.Text = dateInWeek.AddDays(4).ToString("dd.MM");
                    break;
                case DayOfWeek.Wednesday:
                    MonDate.Text = dateInWeek.AddDays(-2).ToString("dd.MM");
                    TuesDate.Text = dateInWeek.AddDays(-1).ToString("dd.MM");
                    WedDate.Text = dateInWeek.AddDays(0).ToString("dd.MM");
                    ThurDate.Text = dateInWeek.AddDays(1).ToString("dd.MM");
                    FridDate.Text = dateInWeek.AddDays(2).ToString("dd.MM");
                    SatDate.Text = dateInWeek.AddDays(3).ToString("dd.MM");
                    break;
                case DayOfWeek.Thursday:
                    MonDate.Text = dateInWeek.AddDays(-3).ToString("dd.MM");
                    TuesDate.Text = dateInWeek.AddDays(-2).ToString("dd.MM");
                    WedDate.Text = dateInWeek.AddDays(-1).ToString("dd.MM");
                    ThurDate.Text = dateInWeek.AddDays(0).ToString("dd.MM");
                    FridDate.Text = dateInWeek.AddDays(1).ToString("dd.MM");
                    SatDate.Text = dateInWeek.AddDays(2).ToString("dd.MM");
                    break;
                case DayOfWeek.Friday:
                    MonDate.Text = dateInWeek.AddDays(-4).ToString("dd.MM");
                    TuesDate.Text = dateInWeek.AddDays(-3).ToString("dd.MM");
                    WedDate.Text = dateInWeek.AddDays(-2).ToString("dd.MM");
                    ThurDate.Text = dateInWeek.AddDays(-1).ToString("dd.MM");
                    FridDate.Text = dateInWeek.AddDays(0).ToString("dd.MM");
                    SatDate.Text = dateInWeek.AddDays(1).ToString("dd.MM");
                    break;
                case DayOfWeek.Saturday:
                    MonDate.Text = dateInWeek.AddDays(-5).ToString("dd.mm");
                    TuesDate.Text = dateInWeek.AddDays(-4).ToString("dd.mm");
                    WedDate.Text = dateInWeek.AddDays(-3).ToString("dd.mm");
                    ThurDate.Text = dateInWeek.AddDays(-2).ToString("dd.mm");
                    FridDate.Text = dateInWeek.AddDays(-1).ToString("dd.mm");
                    SatDate.Text = dateInWeek.AddDays(0).ToString("dd.mm");
                    break;
            }

            foreach (Webinar webinar in webinars)
            {
                WeekLesson wl = new WeekLesson(webinar);

                if (webinar.StartTime.HasValue) {
                    switch (webinar.StartTime.Value.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            Grid.SetColumn(wl, 1);
                            break;
                        case DayOfWeek.Tuesday:
                            Grid.SetColumn(wl, 2);
                            break;
                        case DayOfWeek.Wednesday:
                            Grid.SetColumn(wl, 3);
                            break;
                        case DayOfWeek.Thursday:
                            Grid.SetColumn(wl, 4);
                            break;
                        case DayOfWeek.Friday:
                            Grid.SetColumn(wl, 5);
                            break;
                        case DayOfWeek.Saturday:
                            Grid.SetColumn(wl, 6);
                            break;
                    }

                    if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 9, 0, 0) && 
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 10, 30, 0))
                    {
                        Grid.SetRow(wl, 1);
                    } else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 10, 40, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 12, 10, 0))
                    {
                        Grid.SetRow(wl, 2);
                    }
                    else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 13, 10, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 14, 40, 0))
                    {
                        Grid.SetRow(wl, 3);
                    }
                    else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 14, 50, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 16, 20, 0))
                    {
                        Grid.SetRow(wl, 4);
                    }
                    else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 16, 30, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 18, 0, 0))
                    {
                        Grid.SetRow(wl, 5);
                    }
                    else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 18, 10, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 19, 40, 0))
                    {
                        Grid.SetRow(wl, 6);
                    }
                    else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 18, 30, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 20, 0, 0))
                    {
                        Grid.SetRow(wl, 7);
                    }
                    else if (new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) > new DateTime(0, 0, 0, 20, 10, 0) &&
                        new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) < new DateTime(0, 0, 0, 21, 40, 0))
                    {
                        Grid.SetRow(wl, 8);
                    }

                    lessonsContainers.Children.Add(wl);
                }
            }
        }
    }
}
