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

namespace lab1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitControls();
        }

        static int count = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }

        

        Grid myGrid = new Grid();
        Button[] arr_buttons = new Button[25];
        TextBlock[] arr_textblocks = new TextBlock[2];
        private void InitControls()
        {
            this.Title = "Window2";
            this.Height = 371;
            this.Width = 629;
            this.WindowStyle = WindowStyle.None;


            myGrid.Width = 629;
            myGrid.Height = 371;
            Brush GridColor = new SolidColorBrush(Color.FromRgb(234, 193, 184));
            myGrid.Background = GridColor;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            int counter = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                { 
                    Button tictacbutton = new Button
                    {
                        Name = $"b{counter}", Content = "",
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = 40, Width = 40, VerticalAlignment = VerticalAlignment.Top,
                        BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                        Background = new SolidColorBrush(Color.FromRgb(184, 188, 234)),
                        Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                        FontSize = 20,
                        Margin = new Thickness(65 + i * 40, 106 + j * 40, 0, 0),
                    };
                    tictacbutton.Click += Button_Click_1;
                    arr_buttons[counter - 1] = tictacbutton;
                    counter++;
                    myGrid.Children.Add(tictacbutton);
                }
            }

            
            TextBlock tictactoetext = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 43, Width = 192, FontSize = 36,
                Margin = new Thickness(0, 26, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(154, 162, 247)),
                Text = "Tic-tac-toe",
            };
            arr_textblocks[0] = tictactoetext;
            myGrid.Children.Add(tictactoetext);

            TextBlock TextWinner = new TextBlock
            {
                Name = "TextWinner",
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 60,
                Width = 173,
                FontSize = 22,
                Margin = new Thickness(410, 140, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                Text = "",
            };
            arr_textblocks[1] = TextWinner;
            myGrid.Children.Add(TextWinner);

            Button restart = new Button
            {
                Content = "Restart",
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 46,
                Width = 127,
                FontSize = 16,
                Margin = new Thickness(456, 200, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                Background = new SolidColorBrush(Color.FromRgb(184, 188, 234)),
            };
            restart.Click += click_restart;
            myGrid.Children.Add(restart);

            Button BackToMenu = new Button
            {
                Content = "Back to menu",
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 46,
                Width = 127,
                FontSize = 16,
                Margin = new Thickness(456, 292, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                Background = new SolidColorBrush(Color.FromRgb(184, 188, 234)),
            };
            BackToMenu.Click += Button_Click;
            myGrid.Children.Add(BackToMenu);

            this.Content = myGrid;
        }


        TextBlock TextWinner = new TextBlock();
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


            foreach (TextBlock b in myGrid.Children.OfType<TextBlock>())
            {
                if (b.Name == "TextWinner")
                    TextWinner = b;
            }

            if (TextWinner.Text != "")
            {
                arr_buttons[0].IsEnabled = arr_buttons[1].IsEnabled = arr_buttons[2].IsEnabled = 
                arr_buttons[3].IsEnabled =
                arr_buttons[4].IsEnabled = arr_buttons[5].IsEnabled = arr_buttons[6].IsEnabled = 
                arr_buttons[7].IsEnabled = arr_buttons[8].IsEnabled = arr_buttons[9].IsEnabled =
                arr_buttons[10].IsEnabled = arr_buttons[11].IsEnabled = arr_buttons[12].IsEnabled = 
                arr_buttons[13].IsEnabled = arr_buttons[14].IsEnabled = arr_buttons[15].IsEnabled =
                arr_buttons[16].IsEnabled = arr_buttons[17].IsEnabled = arr_buttons[18].IsEnabled =
                arr_buttons[19].IsEnabled =
                arr_buttons[20].IsEnabled = arr_buttons[21].IsEnabled = arr_buttons[22].IsEnabled =
                arr_buttons[23].IsEnabled = arr_buttons[24].IsEnabled = false;
            }

        }


        public void Find_Winner()
        {
            if (arr_buttons[0].Content == arr_buttons[1].Content && arr_buttons[1].Content == arr_buttons[2].Content &&
                arr_buttons[2].Content == arr_buttons[3].Content && !arr_buttons[0].IsEnabled)
            {
                if (arr_buttons[0].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
                
            else if (arr_buttons[4].Content == arr_buttons[1].Content && arr_buttons[1].Content == arr_buttons[2].Content &&
                arr_buttons[2].Content == arr_buttons[3].Content && !(arr_buttons[3].IsEnabled))
            {
                if (arr_buttons[4].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[5].Content == arr_buttons[6].Content && 
                arr_buttons[6].Content == arr_buttons[7].Content && arr_buttons[7].Content == arr_buttons[8].Content && 
                !(arr_buttons[8].IsEnabled))
            {
                if (arr_buttons[5].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[9].Content == arr_buttons[6].Content && arr_buttons[6].Content == 
                arr_buttons[7].Content && arr_buttons[7].Content == arr_buttons[8].Content && !(arr_buttons[8].IsEnabled))
            {
                if (arr_buttons[9].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[10].Content == arr_buttons[11].Content && arr_buttons[11].Content ==
                arr_buttons[12].Content && arr_buttons[12].Content == arr_buttons[13].Content && !(arr_buttons[13].IsEnabled))
            {
                if (arr_buttons[10].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[14].Content == arr_buttons[11].Content && arr_buttons[11].Content ==
                arr_buttons[12].Content && arr_buttons[12].Content == arr_buttons[13].Content && !(arr_buttons[12].IsEnabled))
            {
                if (arr_buttons[14].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[15].Content == arr_buttons[16].Content && arr_buttons[16].Content ==
                arr_buttons[17].Content && arr_buttons[17].Content == arr_buttons[18].Content && !(arr_buttons[18].IsEnabled))
            {
                if (arr_buttons[15].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[19].Content == arr_buttons[16].Content && arr_buttons[16].Content ==
                arr_buttons[17].Content && arr_buttons[17].Content == arr_buttons[18].Content && !(arr_buttons[18].IsEnabled))
            {
                if (arr_buttons[16].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[23].Content == arr_buttons[20].Content && arr_buttons[20].Content ==
                arr_buttons[21].Content && arr_buttons[21].Content == arr_buttons[22].Content && !(arr_buttons[20].IsEnabled))
            {
                if (arr_buttons[20].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[23].Content == arr_buttons[24].Content && arr_buttons[24].Content ==
                arr_buttons[21].Content && arr_buttons[21].Content == arr_buttons[22].Content && !(arr_buttons[24].IsEnabled))
            {
                if (arr_buttons[23].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (arr_buttons[0].Content == arr_buttons[5].Content && arr_buttons[10].Content == arr_buttons[5].Content &&
                arr_buttons[10].Content == arr_buttons[15].Content && !(arr_buttons[15].IsEnabled))
            {
                if (arr_buttons[0].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[20].Content == arr_buttons[5].Content && arr_buttons[10].Content == 
                arr_buttons[5].Content && arr_buttons[10].Content == arr_buttons[15].Content && !(arr_buttons[15].IsEnabled))
            {
                if (arr_buttons[20].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[1].Content == arr_buttons[6].Content && arr_buttons[11].Content == arr_buttons[6].Content &&
                arr_buttons[11].Content == arr_buttons[16].Content && !(arr_buttons[16].IsEnabled))
            {
                if (arr_buttons[11].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[21].Content == arr_buttons[6].Content && arr_buttons[11].Content ==
                arr_buttons[6].Content && arr_buttons[11].Content == arr_buttons[16].Content && !(arr_buttons[16].IsEnabled))
            {
                if (arr_buttons[11].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[2].Content == arr_buttons[7].Content && arr_buttons[7].Content ==
                arr_buttons[12].Content && arr_buttons[12].Content == arr_buttons[17].Content && !(arr_buttons[17].IsEnabled))
            {
                if (arr_buttons[12].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[22].Content == arr_buttons[7].Content && arr_buttons[7].Content == 
                arr_buttons[12].Content && arr_buttons[12].Content == arr_buttons[17].Content && !(arr_buttons[17].IsEnabled))
            {
                if (arr_buttons[12].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[3].Content == arr_buttons[8].Content && arr_buttons[8].Content == 
                arr_buttons[13].Content && arr_buttons[13].Content == arr_buttons[18].Content && !(arr_buttons[18].IsEnabled))
            {
                if (arr_buttons[13].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[23].Content == arr_buttons[8].Content && arr_buttons[8].Content ==
                arr_buttons[13].Content && arr_buttons[13].Content == arr_buttons[18].Content && !(arr_buttons[18].IsEnabled))
            {
                if (arr_buttons[13].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[4].Content == arr_buttons[9].Content && arr_buttons[9].Content ==
                arr_buttons[14].Content && arr_buttons[14].Content == arr_buttons[19].Content && !(arr_buttons[19].IsEnabled))
            {
                if (arr_buttons[14].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[24].Content == arr_buttons[9].Content && arr_buttons[9].Content ==
                arr_buttons[14].Content && arr_buttons[14].Content == arr_buttons[19].Content && !(arr_buttons[19].IsEnabled))
            {
                if (arr_buttons[14].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (arr_buttons[4].Content == arr_buttons[8].Content && arr_buttons[8].Content ==
                arr_buttons[12].Content && arr_buttons[12].Content == arr_buttons[16].Content && !(arr_buttons[16].IsEnabled))
            {
                if (arr_buttons[12].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[20].Content == arr_buttons[8].Content && arr_buttons[8].Content == 
                arr_buttons[12].Content && arr_buttons[12].Content == arr_buttons[16].Content && !(arr_buttons[16].IsEnabled))
            {
                if (arr_buttons[12].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (arr_buttons[0].Content == arr_buttons[6].Content && arr_buttons[12].Content == 
                arr_buttons[6].Content && arr_buttons[12].Content == arr_buttons[18].Content && !(arr_buttons[18].IsEnabled))
            {
                if (arr_buttons[12].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[24].Content == arr_buttons[6].Content && arr_buttons[12].Content ==
                arr_buttons[6].Content && arr_buttons[12].Content == arr_buttons[18].Content && !(arr_buttons[18].IsEnabled))
            {
                if (arr_buttons[12].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (arr_buttons[1].Content == arr_buttons[7].Content && arr_buttons[7].Content ==
                arr_buttons[13].Content && arr_buttons[13].Content == arr_buttons[19].Content && !(arr_buttons[19].IsEnabled))
            {
                if (arr_buttons[13].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[5].Content == arr_buttons[11].Content && arr_buttons[11].Content ==
                arr_buttons[17].Content && arr_buttons[17].Content == arr_buttons[23].Content && !(arr_buttons[23].IsEnabled))
            {
                if (arr_buttons[17].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }

            else if (arr_buttons[3].Content == arr_buttons[7].Content && arr_buttons[7].Content ==
                arr_buttons[11].Content && arr_buttons[11].Content == arr_buttons[15].Content && !(arr_buttons[15].IsEnabled))
            {
                if (arr_buttons[11].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
            else if (arr_buttons[21].Content == arr_buttons[17].Content && arr_buttons[17].Content ==
                arr_buttons[13].Content && arr_buttons[13].Content == arr_buttons[9].Content && !(arr_buttons[9].IsEnabled))
            {
                if (arr_buttons[13].Content == "x")
                    TextWinner.Text = "Winner X";
                else TextWinner.Text = "Winner O";

            }
        }

        private void click_restart(object sender, RoutedEventArgs e)
        {
            arr_buttons[0].IsEnabled = arr_buttons[1].IsEnabled = arr_buttons[2].IsEnabled =
                arr_buttons[3].IsEnabled =
                arr_buttons[4].IsEnabled = arr_buttons[5].IsEnabled = arr_buttons[6].IsEnabled =
                arr_buttons[7].IsEnabled = arr_buttons[8].IsEnabled = arr_buttons[9].IsEnabled =
                arr_buttons[10].IsEnabled = arr_buttons[11].IsEnabled = arr_buttons[12].IsEnabled =
                arr_buttons[13].IsEnabled = arr_buttons[14].IsEnabled = arr_buttons[15].IsEnabled =
                arr_buttons[16].IsEnabled = arr_buttons[17].IsEnabled = arr_buttons[18].IsEnabled =
                arr_buttons[19].IsEnabled =
                arr_buttons[20].IsEnabled = arr_buttons[21].IsEnabled = arr_buttons[22].IsEnabled =
                arr_buttons[23].IsEnabled = arr_buttons[24].IsEnabled = true;

                arr_buttons[0].Content = arr_buttons[1].Content = arr_buttons[2].Content =
                arr_buttons[3].Content =
                arr_buttons[4].Content = arr_buttons[5].Content = arr_buttons[6].Content = " ";
                arr_buttons[7].Content = arr_buttons[8].Content = arr_buttons[9].Content =
                arr_buttons[10].Content = arr_buttons[11].Content = arr_buttons[12].Content =
                arr_buttons[13].Content = arr_buttons[14].Content = arr_buttons[15].Content =
                arr_buttons[16].Content = arr_buttons[17].Content = arr_buttons[18].Content =
                arr_buttons[19].Content = arr_buttons[20].Content = arr_buttons[21].Content = arr_buttons[22].Content =
                arr_buttons[23].Content = arr_buttons[24].Content = " ";

            TextWinner.Text = "";
        }
    }
}
