using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Console;

namespace lab1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    struct student
    {
        private string ID;
        private string Name;
        public student(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public string getID() => ID;
        public string getName() => Name;
        public void PrintStudent(StreamWriter file)
        {
            file.Write($"{ ID,5}");
            file.Write($"{ Name,10}");
            file.WriteLine();
        }
    }



    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        static List<student> students = new List<student>();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StreamWriter Add = new StreamWriter("textfile.txt", true);

            Add.WriteLine(ID_student.Text + " " + Name_student.Text + " " + Info_student.Text);
            students.Add(new student(ID_student.Text, Name_student.Text + Info_student.Text));

            Add.Close();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StreamReader Find = new StreamReader("textfile.txt");
            student del = new student();

            foreach (var s in students)
                if (s.getID() == ID_student.Text)
                    del = s;
              
            students.Remove(del);
            Find.Close();

            StreamWriter Delete = new StreamWriter("textfile.txt");
            foreach (student s in students)
            {
                s.PrintStudent(Delete);
            }

            Delete.Close();

        }
    }
}
