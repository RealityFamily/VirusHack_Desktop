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

            switch (webinar.TypeLesson)
            {
                case LessonType.Practic:
                    Type.Text = "Практическая работа";
                    break;
                case LessonType.Lecture:
                    Type.Text = "Лекция";
                    break;
                case LessonType.Lab:
                    Type.Text = "Лабораторная работа";
                    break;
            }
            Discipline.Text = webinar.Discipline;
            if (webinar.Teacher != null) {
                Teacher.Text = webinar.Teacher.LastName + " " + webinar.Teacher.FirstName[0] + ".";
            }
            if (webinar.StartTime.HasValue) {
                StartTimeDate.Text = webinar.StartTime.Value.Date.ToString("dd.MM.yyyy");
                StartTimeTime.Text = webinar.StartTime.Value.ToString("HH:mm");
            }

            if (webinar.Groups != null)
            {
                foreach (Group group in webinar.Groups)
                {
                    TextBlock tb = new TextBlock()
                    {
                        FontSize = 18,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2b2b2b")),
                        Text = group.Name
                    };
                    GroupsContainer.Children.Add(tb);
                }
            }

            if (webinar.Files != null) {
                foreach (ModelFile file in webinar.Files)
                {
                    FileLine fl = new FileLine(file.Name, file.Link);
                    FilesList.Children.Add(fl);
                }
            }
        }
    }
}
