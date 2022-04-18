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
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        public static PointCollection pC = new PointCollection();
        List<Example> ListOfExaples = new List<Example>();
        Random index = new Random();

        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();
            GetBestWay();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
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

        private void PlotWay(int[] BestWayIndex)
        {
            PointCollection Points = new PointCollection();
            MyCanvas.Children.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }


            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);


        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
            GetBestWay();
        }

        private void OneStep(object sender, EventArgs e)
        {
            Population_Create();
        }

        private void GetBestWay()
        {
            ListOfExaples.Clear();
            Random rnd = new Random();
            int[] way = new int[PointCount];

            for (int i = 0; i < PointCount; i++)
                way[i] = i;

            for (int s = 0; s < 10; s++)
            {
                int[] way2 = new int[PointCount];
                int i1, i2, tmp;

                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
                Array.Copy(way, way2, PointCount);
                ListOfExaples.Add(new Example(way2, 0));

            }
        }


        private void Population_Create()
        {
            for (int j = ListOfExaples.Count - 1; j >= 10; j--)
            {
                ListOfExaples.RemoveAt(j);
            }

            Crossing();

            MyCanvas.Children.Clear();

            PointCollection Points = new PointCollection();
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }

            int[] Way = ListOfExaples[0].getWay();

            for (int i = 0; i < Way.Length; i++)
            {
                Points.Add(pC[Way[i]]);

            }
                

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }

        public void Crossing()
        {
            bool flag = false;
            bool flag1 = false;
            List<int> arrofel = new List<int>();

            for (int i = 0; i < 10; i++)
            {

                Example e = new Example();
                int[] WayGen = new int[PointCount];
                int mg, fg;

                mg = index.Next(10);
                fg = index.Next(10);

                e = ListOfExaples[mg];
                for (int j = 0; j <= PointCount / 2; j++)
                    WayGen[j] = e.getWay()[j];

                e = ListOfExaples[fg];
                for (int j = PointCount - PointCount / 2 - 1; j < PointCount; j++)
                    WayGen[j] = e.getWay()[j];

                for (int k = 0; k < PointCount; k++)
                {
                    flag1 = false;
                    for (int t = 0; t < PointCount; t++)
                        if (WayGen[t] == k) flag1 = true;

                    if (flag1 == false)
                        arrofel.Add(k);
                }

                if (arrofel.Count > 0)
                {
                    int numlist = 0;

                    for (int k = 0; k < PointCount; k++)
                    {
                        flag = false;
                        for (int t = 0; t < PointCount; t++)
                        {
                            if (WayGen[t] == k && flag == false) flag = true;
                            else if (WayGen[t] == k && flag == true)
                            {
                                WayGen[t] = arrofel[numlist];
                                numlist++;
                            }
                        }
                    }
                }

                int tmp, i1, i2;
                i1 = index.Next(PointCount);
                i2 = index.Next(PointCount);
                int[] way2 = new int[PointCount];
                tmp = WayGen[i1];
                WayGen[i1] = WayGen[i2];
                WayGen[i2] = tmp;
                Array.Copy(WayGen, way2, PointCount);
                ListOfExaples.Add(new Example(way2, 0));
                arrofel.Clear();
            }


            for (int i = 0; i < ListOfExaples.Count; i++)
            {
                Example e = new Example(ListOfExaples[i].getWay(), 0);
                e.countLen(pC);
                ListOfExaples[i] = e;
            }

            Sort();

        }

        public void Sort()
        {
            int min;

            for (int i = 0; i < ListOfExaples.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < ListOfExaples.Count; j++)
                {
                    if (ListOfExaples[j].getLen() < ListOfExaples[min].getLen())
                        min = j;
                }

                if (i != min)
                {
                    Example temp = new Example(ListOfExaples[min].getWay(), ListOfExaples[min].getLen());
                    ListOfExaples[min] = ListOfExaples[i];
                    ListOfExaples[i] = temp;
                }
            }

            PlotWay(ListOfExaples[0].getWay());

        }


        struct Example
        {
            private int[] Way;
            public double Len;
            public Example(int[] Way, double Len)
            {
                this.Way = Way;
                this.Len = Len;
            }
            public int[] getWay() => Way;
            public double getLen() => Len;
            public void countLen(PointCollection pC)
            {
                double len;
                double sum = 0;
                int c_x, c_y, c1_x, c1_y;

                for (int i = 0; i < Way.Length; i++)
                {
                    if (i == Way.Length - 1)
                    {
                        c_x = (int)pC[Way[i]].X;
                        c_y = (int)pC[Way[i]].Y;

                        c1_x = (int)pC[Way[0]].X;
                        c1_y = (int)pC[Way[0]].Y;

                        c_x = c_x - c1_x;
                        c_y = c_y - c1_y;

                    }

                    else
                    {
                        c_x = (int)pC[Way[i]].X;
                        c_y = (int)pC[Way[i]].Y;

                        c1_x = (int)pC[Way[i + 1]].X;
                        c1_y = (int)pC[Way[i + 1]].Y;

                        c_x = c_x - c1_x;
                        c_y = c_y - c1_y;
                    }

                    len = Sqrt(c_x * c_x + c_y * c_y);
                    sum += len;
                }

                this.Len = sum;
            }

        }

    }
}



