using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для Week.xaml
    /// </summary>
    public partial class Week : Page
    {
        List<Webinar> webinars = new List<Webinar>();
        DateTime localDateTime = DateTime.Now;
        bool weekendView = true;

        public Week()
        {
            InitializeComponent();

            InfoBlock.Navigate(new WebinarInfo(new Webinar()
            {
                Files = new List<ModelFile>()
            }));

            CalendarView.Navigate(new WeekCalendar(webinars, localDateTime));
            Date.Text = StartOfWeek(localDateTime).ToString("dd") + " - " + EndOfWeek(localDateTime).ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            weekNum.Text = WeekNum(localDateTime) + " неделя";
        }

        private void AccountInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoBlock.Navigate(new UserInfo(new User()
            {
                FirstName = "Владислав",
                LastName = "Мельник",
                Email = "melnik.v.@edu.mirea.ru",
                Group = "ИНБО-01-17",
                UserStatus = UserStatus.Student
            }));
        }

        private DateTime StartOfWeek(DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        private DateTime EndOfWeek(DateTime dt)
        {
            int diff = (7 + (DayOfWeek.Sunday - dt.DayOfWeek)) % 7;
            return dt.AddDays(diff).Date;
        }

        private int WeekNum(DateTime dt)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dt);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                dt = dt.AddDays(3);
            }

            int answer = 0;
            if (new DateTime(localDateTime.Year, localDateTime.Month, 1) >= new DateTime(localDateTime.Year, 9, 1) &&
                new DateTime(localDateTime.Year, localDateTime.Month, 1) <= new DateTime(localDateTime.Year, 12, 1))
            {
                answer = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 
                    CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(new DateTime(localDateTime.Year, 9, 1), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            } else if (new DateTime(localDateTime.Year, localDateTime.Month, 1) >= new DateTime(localDateTime.Year, 2, 7) &&
                new DateTime(localDateTime.Year, localDateTime.Month, 1) <= new DateTime(localDateTime.Year, 5, 1))
            {
                answer = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) -
                    CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(new DateTime(localDateTime.Year, 2, 7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
            return answer;
        }

        private void nextWeek_Click(object sender, RoutedEventArgs e)
        {
            if (weekendView) {
                localDateTime = localDateTime.AddDays(7);
                CalendarView.Navigate(new WeekCalendar(webinars, localDateTime));
                Date.Text = StartOfWeek(localDateTime).ToString("dd") + " - " + EndOfWeek(localDateTime).ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            } else
            {
                localDateTime = localDateTime.AddDays(1);
                CalendarView.Navigate(new DayCalendar());
                Date.Text = localDateTime.ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            }
            weekNum.Text = WeekNum(localDateTime) + " неделя";
        }

        private void prevWeek_Click(object sender, RoutedEventArgs e)
        {
            if (weekendView)
            {
                localDateTime = localDateTime.AddDays(-7);
                CalendarView.Navigate(new WeekCalendar(webinars, localDateTime));
                Date.Text = StartOfWeek(localDateTime).ToString("dd") + " - " + EndOfWeek(localDateTime).ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            }
            else
            {
                localDateTime = localDateTime.AddDays(-1);
                CalendarView.Navigate(new DayCalendar());
                Date.Text = localDateTime.ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            }
            weekNum.Text = WeekNum(localDateTime) + " неделя";
        }

        private void DayView_Click(object sender, RoutedEventArgs e)
        {
            localDateTime = DateTime.Now;

            weekendView = false;

            DayView.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0A67A3"));
            DayView.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));

            Date.Text = localDateTime.ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            weekNum.Text = WeekNum(localDateTime) + " неделя";
            CalendarView.Navigate(new DayCalendar());

            WeekView.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8E00"));
            WeekView.Foreground = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#000000"));
        }

        private void WeekView_Click(object sender, RoutedEventArgs e)
        {
            localDateTime = DateTime.Now;

            weekendView = true;

            WeekView.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0A67A3"));
            WeekView.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));

            Date.Text = StartOfWeek(localDateTime).ToString("dd") + " - " + EndOfWeek(localDateTime).ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            weekNum.Text = WeekNum(localDateTime) + " неделя";
            CalendarView.Navigate(new WeekCalendar(webinars, localDateTime));

            DayView.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8E00"));
            DayView.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }
    }
}
