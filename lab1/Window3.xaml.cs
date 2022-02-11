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
using System.Windows.Shapes;
using static System.Math;

namespace lab1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        static string sign = "";
        static bool flag;
        static double res = 0;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (flag)
            {
                string[] fulltext = TextBoxCul.Text.Split(' ');


                double a;
                double b;


                if (fulltext[0].Contains(','))
                {
                    string[] first = fulltext[0].Split(',');
                    int doublepart = first[1].Length;
                    a = Convert.ToInt32(first[0]) + Convert.ToInt32(first[1]) / (Pow(10, doublepart));
                }
                else
                {
                    a = Convert.ToInt32(fulltext[0]);
                }


                if (fulltext[2].Contains(','))
                {
                    string[] second = fulltext[2].Split(',');
                    int doublepart = second[1].Length;
                    b = Convert.ToInt32(second[0]) + Convert.ToInt32(second[1]) / (Math.Pow(10, doublepart));
                }
                else
                {
                    b = Convert.ToInt32(fulltext[2]);
                }
                 
                

                switch (sign)
                {
                    case "+":
                        res = Round(a + b, 6);
                        break;
                    case "-":
                        res = Round(a - b, 6);
                        break;
                    case "*":
                        res = Round(a * b, 6);
                        break;
                    case "/":
                        res = Round(a / b, 6);
                        break;
                }

                flag = false;
                TextBoxCul.Text = Convert.ToString(res);
                
            }
            */
        }


        public void Count_cul ()
        {
            string[] fulltext = TextBoxCul.Text.Split(sign);


            double a;
            double b;


            if (fulltext[0].Contains(','))
            {
                string[] first = fulltext[0].Split(',');
                int doublepart = first[1].Length;
                a = Convert.ToInt32(first[0]) + Convert.ToInt32(first[1]) / (Pow(10, doublepart));
            }
            else
            {
                a = Convert.ToDouble(fulltext[0]);
            }


            if (fulltext[1].Contains(','))
            {
                string[] second = fulltext[1].Split(',');
                int doublepart = second[1].Length;
                b = Convert.ToInt32(second[0]) + Convert.ToInt32(second[1]) / (Math.Pow(10, doublepart));
            }
            else
            {
                b = Convert.ToDouble(fulltext[1]);
            }



            switch (sign)
            {
                case "+":
                    res = Round(a + b, 6);
                    break;
                case "-":
                    res = Round(a - b, 6);
                    break;
                case "*":
                    res = Round(a * b, 6);
                    break;
                case "/":
                    res = Round(a / b, 6);
                    break;
            }

            flag = false;
            TextBoxCul.Text = Convert.ToString(res);
        }




        private void click_b5(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "5";
        }

        private void click_b1(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "1";
        }

        private void click_b2(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "2";
        }

        private void click_b3(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "3";
        }

        private void click_b4(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "4";
        }

        private void click_b6(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "6";
        }

        private void click_b7(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "7";
        }

        private void click_b8(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "8";
        }

        private void click_b9(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "9";
        }

        private void click_b0(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += "0";
        }

        private void click_bcomma(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text += ",";
        }

        private void click_mul(object sender, RoutedEventArgs e)
        {
            if (sign != "")
            {
                Count_cul();

            }
            TextBoxCul.Text += "*";
            sign = "*";
        }

        private void click_div(object sender, RoutedEventArgs e)
        {
            if (sign != "")
            {
                Count_cul();

            }
            TextBoxCul.Text += "/";
            sign = "/";
        }

        private void click_dif(object sender, RoutedEventArgs e)
        {
            if (sign != "")
            {
                Count_cul();

            }
            TextBoxCul.Text += "-";
            sign = "-";
        }

        private void click_sum(object sender, RoutedEventArgs e)
        {
            if (sign != "")
            {
                Count_cul();

            }
            TextBoxCul.Text += "+";
            sign = "+";
        }

        private void click_C(object sender, RoutedEventArgs e)
        {
            TextBoxCul.Text = "";
            sign = "";
        }

        private void click_delete(object sender, RoutedEventArgs e)
        {
            string text = TextBoxCul.Text;
            string newtext = "";

            for (int i = 0; i < text.Length - 1; i++)
            {
                newtext += text[i];
            }
            TextBoxCul.Text = newtext;
        }

        private void click_pm(object sender, RoutedEventArgs e)
        {
            res *= -1;
            TextBoxCul.Text = Convert.ToString(res);
        }

        private void click_res(object sender, RoutedEventArgs e)
        {
            flag = true;
            //TextBoxCul.Text += "=";
            Count_cul();
            sign = "";
        }
    }
}
