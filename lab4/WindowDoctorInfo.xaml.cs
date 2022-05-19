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
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace db_registration
{
    /// <summary>
    /// Interaction logic for WindowDoctorInfo.xaml
    /// </summary>
    public partial class WindowDoctorInfo : Window
    {
        private static String Connection = @"Data Source=VLADYSLAVA\MSSQLSERVER01;Initial Catalog=db_hospital;Integrated Security=True";

        SqlDataAdapter Data;
        SqlDataAdapter Data1;
        SqlCommand Com;
        DataTable dT1;
        DataTable dT2;
        String strQ;
        SqlConnection sqlConn;

        public WindowDoctorInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string d;
                int id;
                id = Convert.ToInt32(boxID.Text);
                Data = new SqlDataAdapter("select dbo.doctors.Name, dbo.doctors.Surname, dbo.Speciality.Speciality, dbo.doctors.NumWork from dbo.doctors left join dbo.Speciality on dbo.doctors.IDspeciality = dbo.Speciality.IDspeciality where IDdoctor = " + id, sqlConn);
                dT1 = new DataTable("doctors");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < 4; i++)
                    {
                        d = (dT1.Rows[0][i]).ToString();
                        InfoDoc.Text += d;
                        //d = (dT1.Rows[0][1]).ToString();
                        //InfoPat.Text += d;
                        InfoDoc.Text += "\n";
                    }
                InfoDoc.Text += "\n";

                Data1 = new SqlDataAdapter("SELECT * FROM db_hospital.dbo.Timetable where IDdoctor = " + id + " order by dbo.Timetable.Day, dbo.Timetable.Time1", sqlConn);
                dT2 = new DataTable("Timetable");
                Data1.Fill(dT2);

                if (dT2.Rows.Count > 0)
                {
                    for(int i = 0; i < dT2.Rows.Count; i++)
                    {
                        switch (Convert.ToInt32(dT2.Rows[i][2]))
                        {
                            case 1:
                                day1.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;

                            case 2:
                                day2.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;

                            case 3:
                                day3.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;

                            case 4:
                                day4.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;

                            case 5:
                                day5.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;

                            case 6:
                                day6.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;

                            case 7:
                                day7.Text = dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                                break;



                        }

                        /*
                        if (Convert.ToInt32(dT2.Rows[i][2]) == 1)
                        {
                            day1.Text += dT2.Rows[i][3] + ":00-" + dT2.Rows[i][4] + ":00 в к. " + dT2.Rows[i][1];
                        }
                        */
                    }


                }

                    /*
                    for (int i = 1; i < 8; i++)
                    {
                        if (i == 1)
                        {
                            Data1.
                        }


                        d = (dT1.Rows[0][i]).ToString();
                        InfoDoc.Text += d;
                        //d = (dT1.Rows[0][1]).ToString();
                        //InfoPat.Text += d;
                        InfoDoc.Text += "\n";
                        Data1 = null;
                    }
                    */



                    sqlConn.Close();
            }
        }

        private void Button_Click_menu(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Button_Click_adddoc(object sender, RoutedEventArgs e)
        {
            WindowAddDoctor wad = new WindowAddDoctor();
            Hide();
            wad.Show();
        }

        private void button_click_clear(object sender, RoutedEventArgs e)
        {
            InfoDoc.Text = "";
            day1.Text = "-";
            day2.Text = "-";
            day3.Text = "-";
            day4.Text = "-";
            day5.Text = "-";
            day6.Text = "-";
            day7.Text = "-";
        }
    }
}
