using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Math;

namespace Lab_2_First_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static List<Point> pC = new List<Point>();
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            InitPoints();
            InitPolygon();
        }
        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75 * MainWin.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * MainWin.Height - 3 * Radius));
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el);
            }
        }
        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }
        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }
        private void PlotWay(List<Point> Points)
        {
            PointCollection pointC = new PointCollection();
            for (int i = 0; i < Points.Count; i++)
            {
                pointC.Add(Points[i]);
            }
            myPolygon.Points = pointC;
            MyCanvas.Children.Add(myPolygon);
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            Greedy();
            PlotWay(pC);
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
        }

        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            Greedy();
            PlotWay(pC);
        }
        private void Greedy()
        {
            for (int j = 0; j < pC.Count - 1; j++)
            {
                Point point_first = pC[j];
                Point point_next = pC[j + 1];
                Point point_sec = pC[j + 1];

                double Len = CountLen(point_first, point_sec);

                for (int i = j + 2; i < pC.Count; i++)
                {
                    point_sec = pC[i];

                    if (Len > CountLen(point_first, point_sec))
                    {
                        Len = CountLen(point_first, point_sec);
                        point_next = pC[i];
                    }
                }

                Point temp = pC[j + 1];
                int index = pC.IndexOf(point_next);
                pC[j + 1] = point_next;
                pC[index] = temp;
            }
        }
        static double CountLen(Point point1, Point point2)
        {
            double point_x, point_y;
            point_x = point2.X - point1.X;
            point_y = point2.Y - point1.Y;

            double Len = Sqrt(Pow((point_x), 2) + Pow((point_y), 2));

            return Len;
        }
    }
}