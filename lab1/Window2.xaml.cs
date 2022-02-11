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

namespace lab1
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

        static int count = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Button press_button = (Button)e.Source;

            press_button.IsEnabled = false;

            if (count == 0)
            {
                press_button.Content = "x";
                count = 1;
            }
            else
            {
                press_button.Content = "o";
                count = 0;
            }

            Find_Winner();

            if (TextWinner.Text != "")
            {
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = b10.IsEnabled =
                b11.IsEnabled = b12.IsEnabled = b13.IsEnabled = b14.IsEnabled = b15.IsEnabled = b16.IsEnabled = b17.IsEnabled = b18.IsEnabled = b19.IsEnabled = b20.IsEnabled =
                b21.IsEnabled = b22.IsEnabled = b23.IsEnabled = b24.IsEnabled = b25.IsEnabled = false;
            }

        }

        
        public void Find_Winner()
        {
            //if (Convert.ToString(b1.Content) == b2.Content == b3.Content == b4.Content)
            
            if (b1.Content == b2.Content && b2.Content == b3.Content && b3.Content == b4.Content && !(b1.IsEnabled))
            {
                if (b1.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
                
            else if (b5.Content == b2.Content && b2.Content == b3.Content && b3.Content == b4.Content && !(b4.IsEnabled))
            {
                if (b5.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b6.Content == b7.Content && b7.Content == b8.Content && b8.Content == b9.Content && !(b9.IsEnabled))
            {
                if (b6.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b10.Content == b7.Content && b7.Content == b8.Content && b8.Content == b9.Content && !(b9.IsEnabled))
            {
                if (b10.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b11.Content == b12.Content && b12.Content == b13.Content && b13.Content == b14.Content && !(b14.IsEnabled))
            {
                if (b11.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b15.Content == b12.Content && b12.Content == b13.Content && b13.Content == b14.Content && !(b14.IsEnabled))
            {
                if (b15.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b16.Content == b17.Content && b17.Content == b18.Content && b18.Content == b19.Content && !(b19.IsEnabled))
            {
                if (b16.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b20.Content == b17.Content && b17.Content == b18.Content && b18.Content == b19.Content && !(b19.IsEnabled))
            {
                if (b17.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b24.Content == b21.Content && b21.Content == b22.Content && b22.Content == b23.Content && !(b21.IsEnabled))
            {
                if (b21.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b24.Content == b25.Content && b25.Content == b22.Content && b22.Content == b23.Content && !(b25.IsEnabled))
            {
                if (b24.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (b1.Content == b6.Content && b11.Content == b6.Content && b11.Content == b16.Content && !(b16.IsEnabled))
            {
                if (b1.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b21.Content == b6.Content && b11.Content == b6.Content && b11.Content == b16.Content && !(b16.IsEnabled))
            {
                if (b21.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b2.Content == b7.Content && b12.Content == b7.Content && b12.Content == b17.Content && !(b17.IsEnabled))
            {
                if (b12.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b22.Content == b7.Content && b12.Content == b7.Content && b12.Content == b17.Content && !(b17.IsEnabled))
            {
                if (b12.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b3.Content == b8.Content && b8.Content == b13.Content && b13.Content == b18.Content && !(b18.IsEnabled))
            {
                if (b13.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b23.Content == b8.Content && b8.Content == b13.Content && b13.Content == b18.Content && !(b18.IsEnabled))
            {
                if (b13.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b4.Content == b9.Content && b9.Content == b14.Content && b14.Content == b19.Content && !(b19.IsEnabled))
            {
                if (b14.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b24.Content == b9.Content && b9.Content == b14.Content && b14.Content == b19.Content && !(b19.IsEnabled))
            {
                if (b14.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b5.Content == b10.Content && b10.Content == b15.Content && b15.Content == b20.Content && !(b20.IsEnabled))
            {
                if (b15.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b25.Content == b10.Content && b10.Content == b15.Content && b15.Content == b20.Content && !(b20.IsEnabled))
            {
                if (b15.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (b5.Content == b9.Content && b9.Content == b13.Content && b13.Content == b17.Content && !(b17.IsEnabled))
            {
                if (b13.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b21.Content == b9.Content && b9.Content == b13.Content && b13.Content == b17.Content && !(b17.IsEnabled))
            {
                if (b13.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (b1.Content == b7.Content && b13.Content == b7.Content && b13.Content == b19.Content && !(b19.IsEnabled))
            {
                if (b13.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b25.Content == b7.Content && b13.Content == b7.Content && b13.Content == b19.Content && !(b19.IsEnabled))
            {
                if (b13.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (b2.Content == b8.Content && b8.Content == b14.Content && b14.Content == b20.Content && !(b20.IsEnabled))
            {
                if (b14.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b6.Content == b12.Content && b12.Content == b18.Content && b18.Content == b24.Content && !(b24.IsEnabled))
            {
                if (b18.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (b4.Content == b8.Content && b8.Content == b12.Content && b12.Content == b16.Content && !(b16.IsEnabled))
            {
                if (b12.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (b22.Content == b18.Content && b18.Content == b14.Content && b14.Content == b10.Content && !(b10.IsEnabled))
            {
                if (b14.Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
        }

        private void click_restart(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = b10.IsEnabled =
            b11.IsEnabled = b12.IsEnabled = b13.IsEnabled = b14.IsEnabled = b15.IsEnabled = b16.IsEnabled = b17.IsEnabled = b18.IsEnabled = b19.IsEnabled = b20.IsEnabled =
            b21.IsEnabled = b22.IsEnabled = b23.IsEnabled = b24.IsEnabled = b25.IsEnabled = true;

            b1.Content = b2.Content = b3.Content = b4.Content = b5.Content = b6.Content = b7.Content = b8.Content = b9.Content = b10.Content =
            b11.Content = b12.Content = b13.Content = b14.Content = b15.Content = b16.Content = b17.Content = b18.Content = b19.Content = b20.Content =
            b21.Content = b22.Content = b23.Content = b24.Content = b25.Content = " ";

            TextWinner.Text = "";
        }
    }
}
