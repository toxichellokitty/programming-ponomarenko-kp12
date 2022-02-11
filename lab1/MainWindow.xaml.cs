using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_click_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window_students = new Window1();
            Hide();
            window_students.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 window_tictac = new Window2();
            Hide();
            window_tictac.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window3 window_cul = new Window3();
            Hide();
            window_cul.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window4 window_dev = new Window4();
            Hide();
            window_dev.Show();
        }
    }
}
