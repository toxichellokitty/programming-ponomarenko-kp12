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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitControls();
        }

        

        Grid myGrid = new Grid();
        private void InitControls()
        {
            this.Title = "Window4";
            this.Height = 450;
            this.Width = 673;
            this.WindowStyle = WindowStyle.None;

            myGrid.Width = 673;
            myGrid.Height = 450;
            Brush GridColor = new SolidColorBrush(Color.FromRgb(152, 212, 222));
            myGrid.Background = GridColor;


            TextBlock Dev = new TextBlock
            {
                Name = "TextWinner",
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 38,
                Width = 243,
                FontSize = 30,
                Margin = new Thickness(0, 36, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                Text = "About developer",
                
            };
            Dev.TextWrapping = TextWrapping.Wrap;
            myGrid.Children.Add(Dev);

            

            TextBlock NS = new TextBlock
            {
                Name = "TextWinner",
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 45,
                Width = 262,
                FontSize = 18,
                Margin = new Thickness(367, 186, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                Text = "Пономаренко Владислава, КП-12, 2022",

            };
            NS.TextWrapping = TextWrapping.Wrap;
            myGrid.Children.Add(NS);


            Button BackToMenu = new Button
            {
                Content = "Back to main menu",
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 46,
                Width = 127,
                FontSize = 16,
                Margin = new Thickness(460, 331, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                Background = new SolidColorBrush(Color.FromRgb(117, 210, 216)),
            };
            BackToMenu.Click += Button_Click_1;
            myGrid.Children.Add(BackToMenu);

            this.Content = myGrid;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window_menu = new MainWindow();
            Hide();
            window_menu.Show();
        }
    }
}
