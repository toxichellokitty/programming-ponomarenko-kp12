using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            InitControls();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        public Grid myGrid = new Grid();
        private void InitControls()
        {
            this.Title = "Window1";
            this.Height = 450;
            this.Width = 649;
            this.WindowStyle = WindowStyle.None;

            
            myGrid.Width = 649;
            myGrid.Height = 450;
            Brush GridColor = new SolidColorBrush(Color.FromRgb(164, 135, 204));
            myGrid.Background = GridColor;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            
            for (int i = 0; i < 4; i++)
            {
                TextBlock Text1 = new TextBlock();
                
                Text1.Height = 35;
                Text1.TextWrapping = TextWrapping.Wrap;
                Text1.VerticalAlignment = VerticalAlignment.Top;
                Text1.Width = 203;
                Text1.FontSize = 24;
                Text1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                if(i == 0)
                {
                    Text1.Margin = new Thickness(0, 28, 0, 0);
                    Text1.Text = "Student data base";
                    Text1.HorizontalAlignment = HorizontalAlignment.Center;
                }
                else if (i == 1)
                {
                    Text1.Margin = new Thickness(0, 88, 0, 0);
                    Text1.Text = "Enter student ID";
                    Text1.HorizontalAlignment = HorizontalAlignment.Center;
                }
                else if (i == 2)
                {
                    Text1.Margin = new Thickness(58, 166, 0, 0);
                    Text1.Text = "Enter student's full name";
                    Text1.HorizontalAlignment = HorizontalAlignment.Left;
                }
                else
                {
                    Text1.Margin = new Thickness(58, 240, 0, 0);
                    Text1.Text = "Enter additional information";
                    Text1.HorizontalAlignment = HorizontalAlignment.Left;
                }

                myGrid.Children.Add(Text1);
            }

             
            
            for (int i = 0; i < 3; i++)
            {
                TextBox Text2 = new TextBox();
                
                Text2.Height = 28;
                Text2.TextWrapping = TextWrapping.Wrap;
                Text2.VerticalAlignment = VerticalAlignment.Top;
                Text2.Width = 289;
                Text2.FontSize = 17;
                Text2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Brush TextColor = new SolidColorBrush(Color.FromRgb(130, 130, 210));
                myGrid.Background = TextColor;

                if (i == 0)
                {
                    Text2.Margin = new Thickness(0, 122, 0, 0);
                    Text2.Name = "ID_student";
                    Text2.HorizontalAlignment = HorizontalAlignment.Center;
                }
                
                else if (i == 1)
                {
                    Text2.Margin = new Thickness(58, 205, 0, 0);
                    Text2.Name = "Name_student";
                    Text2.HorizontalAlignment = HorizontalAlignment.Left;
                }
                    
                else
                {
                    Text2.Margin = new Thickness(58, 275, 0, 0);
                    Text2.Name = "Info_student";
                    Text2.HorizontalAlignment = HorizontalAlignment.Left;
                }
                myGrid.Children.Add(Text2);
            }

            
            
            for (int i = 0; i < 3; i++)
            {
                Button buttons = new Button();
                buttons.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                buttons.Background = new SolidColorBrush(Color.FromRgb(140, 100, 190));
                buttons.HorizontalAlignment = HorizontalAlignment.Left;
                buttons.VerticalAlignment = VerticalAlignment.Top;

                if (i == 0)
                {
                    buttons.Content = "Back to main menu";
                    buttons.Height = 46;
                    buttons.Margin = new Thickness(450, 347, 0, 0);
                    buttons.Width = 127;
                    buttons.Click += Button_Click_1;
                }
                else if (i == 1)
                {
                    buttons.Content = "Delete student";
                    buttons.Height = 42;
                    buttons.Margin = new Thickness(464, 177, 0, 0);
                    buttons.Width = 100;
                    buttons.Click += Button_Click_3;
                }
                else
                {
                    buttons.Name = "AddStudent";
                    buttons.Content = "Add student";
                    buttons.Height = 42;
                    buttons.Margin = new Thickness(152, 349, 0, 0);
                    buttons.Width = 100;
                    buttons.Click += Button_Click_2;
                }
                myGrid.Children.Add(buttons);
            }

            this.Content = myGrid;
        }

        static List<student> students = new List<student>();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StreamWriter Add = new StreamWriter("textfile.txt", true);

            TextBox IDStudent = new TextBox();
            TextBox NameStudent = new TextBox();
            TextBox InfoStudent = new TextBox();

            foreach (TextBox b in myGrid.Children.OfType<TextBox>())
            {
                if (b.Name == "ID_student")
                    IDStudent = b;

                else if (b.Name == "Name_student")
                    NameStudent = b;

                else
                    InfoStudent = b;
            }

            Add.WriteLine(IDStudent.Text + " " + NameStudent.Text + " " + InfoStudent.Text);
            students.Add(new student(IDStudent.Text, NameStudent.Text + InfoStudent.Text));

            Add.Close();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StreamReader Find = new StreamReader("textfile.txt");
            student del = new student();
            TextBox IDStudent = new TextBox();

            foreach (TextBox b in myGrid.Children.OfType<TextBox>())
            {
                if (b.Name == "ID_student")
                    IDStudent = b;
            }

            foreach (var s in students)
                if (s.getID() == IDStudent.Text)
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
