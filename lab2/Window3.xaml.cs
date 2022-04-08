using System;
using System.Collections.Generic;
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
            InitControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        static string sign = "";
        static double res = 0;
        List<TextBox> CalculateTB = new List<TextBox>();
        Grid myGrid = new Grid();

        private void InitControls()
        {
            this.Title = "Window3";
            this.Height = 390;
            this.Width = 270;
            this.WindowStyle = WindowStyle.None;


            myGrid.Width = 270;
            myGrid.Height = 390;
            Brush GridColor = new SolidColorBrush(Color.FromRgb(230, 230, 230));
            myGrid.Background = GridColor;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;
            


            TextBox CulTextBox = new TextBox
            {
                Name = "TextBoxCul",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 121,
                Width = 240,
                FontSize = 20,
                Margin = new Thickness(10, 10, 0, 0),
                
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                Text = "",
            };
            CalculateTB.Add(CulTextBox);
            myGrid.Children.Add(CulTextBox);

            int counter = 1;

            //for(int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Button CulBut = new Button
                    {
                        Content = "",
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = 45,
                        Width = 60,
                        VerticalAlignment = VerticalAlignment.Top,
                        BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                        Background = new SolidColorBrush(Color.FromRgb(184, 188, 234)),
                        Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                        FontSize = 15,
                        Margin = new Thickness(30 + i * 50, 148 + j * 45, 0, 0),
                    };


                    if (counter == 1)
                    {
                        CulBut.Content = "To menu";
                        CulBut.Click += Button_Click;
                    }

                    else if (counter == 2)
                    {
                        CulBut.Content = "C";
                        CulBut.Click += click_C;
                    }

                    else if (counter == 3)
                    {
                        CulBut.Content = "<=";
                        CulBut.Click += click_delete;
                    }
                    else if (counter == 4)
                    {
                        CulBut.Content = "/";
                        CulBut.Click += click_div;
                    }
                    else if (counter == 5)
                    {
                        CulBut.Content = "7";
                        CulBut.Click += click_b7;
                    }
                    else if (counter == 6)
                    {
                        CulBut.Content = "8";
                        CulBut.Click += click_b8;
                    }
                    else if (counter == 7)
                    {
                        CulBut.Content = "9";
                        CulBut.Click += click_b9;
                    }
                    else if (counter == 8)
                    {
                        CulBut.Content = "*";
                        CulBut.Click += click_mul;
                    }
                    else if (counter == 9)
                    {
                        CulBut.Content = "4";
                        CulBut.Click += click_b4;
                    }
                    else if (counter == 10)
                    {
                        CulBut.Content = "5";
                        CulBut.Click += click_b5;
                    }
                    else if (counter == 11)
                    {
                        CulBut.Content = "6";
                        CulBut.Click += click_b6;
                    }
                    else if (counter == 12)
                    {
                        CulBut.Content = "-";
                        CulBut.Click += click_dif;
                    }
                    else if (counter == 13)
                    {
                        CulBut.Content = "1";
                        CulBut.Click += click_b1;
                    }
                    else if (counter == 14)
                    {
                        CulBut.Content = "2";
                        CulBut.Click += click_b2;
                    }
                    else if (counter == 15)
                    {
                        CulBut.Content = "3";
                        CulBut.Click += click_b3;
                    }
                    else if (counter == 16)
                    {
                        CulBut.Content = "+";
                        CulBut.Click += click_sum;
                    }
                    else if (counter == 17)
                    {
                        CulBut.Content = "+/-";
                        CulBut.Click += click_pm;
                    }
                    else if (counter == 18)
                    {
                        CulBut.Content = "0";
                        CulBut.Click += click_b0;
                    }
                    else if (counter == 19)
                    {
                        CulBut.Content = ",";
                        CulBut.Click += click_bcomma;
                    }
                    else
                    {
                        CulBut.Content = "=";
                        CulBut.Click += click_res;
                    }

                    counter++;
                    myGrid.Children.Add(CulBut);
                }
            }

            this.Content = myGrid;
        }

        TextBox TextBoxCul = new TextBox();

        public void Count_cul ()
        {
            foreach (TextBox temp in myGrid.Children.OfType<TextBox>())
            {
                TextBoxCul = temp;
            }


            string[] fulltext = TextBoxCul.Text.Split(sign);


            double a;
            double b;
            //9,06*8

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
            Count_cul();
            sign = "";
        }
    }
}
