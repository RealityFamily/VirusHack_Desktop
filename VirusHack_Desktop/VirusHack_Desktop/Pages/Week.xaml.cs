using IO.Swagger.Api;
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
using VirusHack_Desktop.Windows;

namespace VirusHack_Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Week.xaml
    /// </summary>
    public partial class Week : Page
    {
        List<Webinar> webinars = new List<Webinar>();
        Webinar localWebinar = new Webinar();
        User user = new User();
        DateTime localDateTime = DateTime.Now;
        bool weekendView = true;
        bool webinInfo = true;

        public Week()
        {
            InitializeComponent();

            var WebinarApiInstance = new WebinApi();
            var UserApiInstance = new UserApi();
            try
            {
                string token = Application.Current.Resources["token"].ToString();
                user = UserApiInstance.GetUserInfo(token);
                webinars = WebinarApiInstance.GetWeekWebinars(token);
            } catch (Exception e) { }

            AccountName.Text = user.LastName + " " + user.FirstName;

            localWebinar = FindCurrentWebinar(webinars);
            InfoBlock.Navigate(new WebinarInfo(localWebinar));

            CalendarView.Navigate(new WeekCalendar(webinars, localDateTime));
            Date.Text = StartOfWeek(localDateTime).ToString("dd") + " - " + EndOfWeek(localDateTime).ToString("dd") + " " + localDateTime.ToString("MMMM", CultureInfo.GetCultureInfo("ru-ru"));
            weekNum.Text = WeekNum(localDateTime) + " неделя";
        }

        private Webinar FindCurrentWebinar(List<Webinar> webinars)
        {
            foreach (Webinar webinar in webinars)
            {
                DateTime tempH = webinar.StartTime.Value.AddHours(1);
                DateTime tempM = webinar.StartTime.Value.AddMinutes(30);

                if (DateTime.Equals(webinar.StartTime.Value.Date, DateTime.Now.Date) &&
                    (new DateTime(0, 0, 0, DateTime.Now.Hour, DateTime.Now.Minute, 0) >= new DateTime(0, 0, 0, webinar.StartTime.Value.Hour, webinar.StartTime.Value.Minute, 0) &&
                        new DateTime(0, 0, 0, DateTime.Now.Hour, DateTime.Now.Minute, 0) < new DateTime(0, 0, 0, tempH.Hour, tempM.Minute, 0)))
                {
                    return webinar;
                }
            }
            return new Webinar();
        }

        private void AccountInfo_Click(object sender, RoutedEventArgs e)
        {
            if (webinInfo) {
                InfoBlock.Navigate(new UserInfo(user));
            } else
            {
                InfoBlock.Navigate(new WebinarInfo(localWebinar));
            }
            webinInfo = !webinInfo;
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
                CalendarView.Navigate(new DayCalendar(webinars, localDateTime));
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
                CalendarView.Navigate(new DayCalendar(webinars, localDateTime));
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
            CalendarView.Navigate(new DayCalendar(webinars, localDateTime));

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

        public void OpenWebinarInfo(Webinar webinar)
        {
            webinInfo = true;
            localWebinar = webinar;
            InfoBlock.Navigate(new WebinarInfo(webinar));
        }

        public void OpenWebinarStatics(Webinar webinar)
        {
            var WebinarApiInstance = new WebinApi();
            Webinar webinar_staistic = webinar;

            try
            {
                webinar_staistic = WebinarApiInstance.GetWebinarStatic(Application.Current.Resources["token"].ToString(), webinar.Id);
            } catch (Exception exc) { }

            ((NavigationWindow)Application.Current.MainWindow).Navigate(new WebinarStatistic(webinar_staistic));
        }

        private void WebinarConnection_Click(object sender, RoutedEventArgs e)
        {
            var WebinarApiInstance = new WebinApi();
            string link = "";
            string pID = "";
            try
            {
                var response = WebinarApiInstance.GetWebinarConnection(Application.Current.Resources["token"].ToString(), localWebinar.Id.Value);
                link = response.Link;
                pID = response.ParticipationID;
            } catch (Exception ex) { }

            if (!string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(pID)) {
                BrowserWindow bw = new BrowserWindow(link, pID);
                bw.Show();
            }
        }
    }
}
