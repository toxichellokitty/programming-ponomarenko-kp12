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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        public double time = 0;
        public bool flag = true;
        public List<List<double>> ListOfTime = new List<List<double>>();
        public List<double> k_student = new List<double>();
        public List<double> ListDisp = new List<double>();
        public List<double> ListDispStudy = new List<double>();
        public List<double> ListMatS = new List<double>();
        public List<double> ListMatS_study = new List<double>();
        public int elemnum = 0;
        public int count_n = 0;
        public int count_p = 0;

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

        private void SaveWord(object sender, RoutedEventArgs e)
        {
            Count_Function(elemnum);
            elemnum++;
            BoxForCodeWord.Text = "";
            flag = true;
        }

        public void Count_Function(int elemnum)
        {
            StreamReader txt = new StreamReader("TextFile.txt");
            string[] Line = txt.ReadLine().Split(" ");
            double sum = 0;
            double sum2 = 0;
            double MatS;
            double Dispression = 0;
            double Fp;
            double FT = 3.79;
            

            for (int k = 0; k < 8; k++)
                sum += ListOfTime[elemnum][k];
            
            MatS = sum / 8;
            ListMatS.Add(MatS);

            for (int k = 0; k < 8; k++)
                sum2 += Pow(Round(ListOfTime[elemnum][k] - MatS, 2), 2);

            Dispression = sum2 / 7;
            ListDisp.Add(Dispression);

            if (Dispression > Convert.ToDouble(Line[1]))
                Fp = Dispression / Convert.ToDouble(Line[1]);
            else Fp = Convert.ToDouble(Line[1]) / Dispression;


            if (Fp > FT)
                count_n++;
            
            else
                count_p++;
            

            if (count_n + count_p == Convert.ToInt32(NumAttempts.Text))
            {
                if (count_n > count_p) TextBoxForFT.Text = "Дисперсії неоднорідні";
                else TextBoxForFT.Text = "Дисперсії рівні";

            }

            txt.Close();

            P_identification();
        }


        public void P_identification()
        {
            double S, tp;
            double tT = 2.31;
            double r = 0;
            double ke = 0;
            
            StreamReader sr = new StreamReader("TextFile.txt");
            while (!sr.EndOfStream)
            {
                string[] str = sr.ReadLine().Split(" ");
                ListDispStudy.Add(Convert.ToDouble(str[1]));
                ListMatS_study.Add(Convert.ToDouble(str[0]));
            }

            for (int i = 0; i < ListDisp.Count; i++)
            {
                for (int j = 0; j < ListDispStudy.Count; j++)
                {
                    double S_xa = ListDisp[i], S_y = ListDispStudy[j];
                    double MatS = ListMatS[i], MatS_study = ListMatS_study[j];

                    S = Sqrt(((Pow(S_xa, 2) + Pow(S_y, 2)) * 7) / 15);
                    tp = Abs(MatS - MatS_study) / (S * Sqrt(2.0 / 8));
                    if (tT >= tp) 
                        r++;
                }
            }

            StreamReader List_ke = new StreamReader("TextFile.txt");

            while (!List_ke.EndOfStream)
            {
                string[] Lines = List_ke.ReadLine().Split(" ");
                foreach (var L in Lines)
                {
                    ke++;
                }
            }

            if (elemnum == Convert.ToInt32(NumAttempts.Text) - 1)
            {
                double P = r / ke;
                TextBoxForP.Text = "Р ідентифікації = " + P;
            }
            

            List_ke.Close();
            sr.Close();
        }

    }
}