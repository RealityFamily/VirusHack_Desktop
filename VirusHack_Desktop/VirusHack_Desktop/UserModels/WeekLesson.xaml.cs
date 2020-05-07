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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VirusHack_Desktop.Pages;

namespace VirusHack_Desktop.UserModels
{
    /// <summary>
    /// Логика взаимодействия для WeekLesson.xaml
    /// </summary>
    public partial class WeekLesson : UserControl
    {
        Webinar webinar;

        public WeekLesson(Webinar webinar)
        {
            InitializeComponent();

            this.webinar = webinar;

            switch (webinar.TypeLesson)
            {
                case LessonType.Practic:
                    Type.Text = "Практическая";
                    break;
                case LessonType.Lecture:
                    Type.Text = "Лекция";
                    break;
                case LessonType.Lab:
                    Type.Text = "Лабораторная";
                    break;
                default:
                    break;
            }

            switch (webinar.LessonStatus)
            {
                case LessonStatus.Future:
                    background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#65A6D1"));
                    break;
                case LessonStatus.Present:
                    background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#96F5F0"));
                    break;
                case LessonStatus.Missed:
                    background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F08FC5"));
                    break;
            }

            Name.Text = webinar.Discipline;

        }

        private void background_Click(object sender, RoutedEventArgs e)
        {
            ((Week)Application.Current.MainWindow.Content).OpenWebinarInfo(webinar);
        }

        private void background_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var UserApiInstance = new UserApi();
            User localUser = UserApiInstance.GetUserInfo(Application.Current.Resources["token"].ToString());
            if (localUser.UserStatus != UserStatus.Student)
            {
                var WebinarApiInstance = new WebinApi();
                Webinar statisWebinar = webinar;
                try
                {
                    statisWebinar = WebinarApiInstance.GetWebinarStatic(Application.Current.Resources["token"].ToString(), webinar.Id);
                } catch (Exception ex) { }
                ((Week)Application.Current.MainWindow.Content).OpenWebinarStatics(statisWebinar);
            }
        }
    }
}
