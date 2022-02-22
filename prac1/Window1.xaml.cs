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
using static System.Math;

namespace prac1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        public void Count_Function (int elemnum)
        {
            double Yi;
            double sum = 0;
            double sum2 = 0;
            double sum3 = 0;
            double tT = 2.31;
            double MatS;
            double Dispression = 0;
            double Average = 0;

            for (int i = 0; i < 8; i++)
            {
                Yi = ListOfTime[elemnum][i];
                ListOfTime[elemnum][i] = 0;

                for (int k = 0; k < 8; k++)
                {
                    sum += ListOfTime[elemnum][k];

                }
                MatS = sum/7;

                for (int k = 0; k < 8; k++)
                    sum2 += Pow(Round(ListOfTime[elemnum][k] - MatS, 2), 2);

                Dispression = sum2 / 6;

                Average = Sqrt(sum2 / 6);

                sum3 += Abs((Yi - MatS) / Average / Sqrt(7));
                k_student.Add(sum3);

                ListOfTime[elemnum][i] = Yi;
            }

            List<double> ListDelete = new List<double>();

            for (int i = 1; i <= 8; i++)
            {
                if (k_student[i - 1] > tT)
                {
                    ListDelete.Add(ListOfTime[elemnum][i - 1]);
                }
            }

            for (int i = 0; i < ListOfTime[elemnum].Count; i++)
                for (int j = 0; j < ListDelete.Count; j++)
                {
                    if (ListOfTime[elemnum][i] == ListDelete[j])
                    {
                        ListOfTime[elemnum].Remove(ListDelete[j]);
                    }
                }

            FunctionWithDeletedList();
        }

        public void FunctionWithDeletedList ()
        {
            
            StreamWriter txt = new StreamWriter("TextFile.txt", true);
            StreamWriter Try = new StreamWriter("TryFile.txt", true);
            
            double sum = 0;
            double sum2 = 0;
            double MatS;
            double Dispression = 0;


                for (int k = 0; k < 8; k++)
                {
                    sum += ListOfTime[elemnum][k];
                }
                MatS = sum / 8;

                for (int k = 0; k < 8; k++)
                    sum2 += Pow(Round(ListOfTime[elemnum][k] - MatS, 2), 2);

                Dispression = sum2 / 7;

                txt.WriteLine(MatS + " " + Dispression);
            
            foreach (var s in ListOfTime)
            {
                foreach(var j in s)
                {
                    Try.Write(j + " ");
                }
                Try.WriteLine();
                
            }

            txt.Close();
            Try.Close();
        }



        public double time = 0;
        public bool flag = true;
        public List<List<double>> ListOfTime = new List<List<double>>();
        public List<double> k_student = new List<double>();
        public int elemnum = 0;
        
        private void SaveWord(object sender, RoutedEventArgs e)
        {
            Count_Function(elemnum);
            elemnum++;
            BoxForCodeWord.Text = "";
            flag = true;
            if (elemnum == Convert.ToInt32(NumAttempts.Text)) 
            {
                BoxForCodeWord.IsEnabled = false;
            }
            
        }

        private void BoxChengeFun(object sender, TextChangedEventArgs e)
        {
            if (BoxForCodeWord.Text != "")
            {
                if (flag)
                {
                    ListOfTime.Add(new List<double>());
                    time = Convert.ToDouble(Convert.ToInt64(DateTime.Now.Ticks) / 10000) / 1000;
                    flag = false;
                }
                else
                {
                    ListOfTime[elemnum].Add(Round(Convert.ToDouble(Convert.ToInt64(DateTime.Now.Ticks) / 10000) / 1000 - time, 3));
                    time = Convert.ToDouble(Convert.ToInt64(DateTime.Now.Ticks) / 10000) / 1000;
                }
            }
        }
    }
}
