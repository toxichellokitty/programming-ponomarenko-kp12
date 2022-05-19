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
    /// Interaction logic for WindowCheckVisit.xaml
    /// </summary>
    public partial class WindowCheckVisit : Window
    {
        private static String Connection = @"Data Source=VLADYSLAVA\MSSQLSERVER01;Initial Catalog=db_hospital;Integrated Security=True";

        SqlDataAdapter Data;
        SqlCommand Com;
        DataTable dT1;
        String strQ;
        SqlConnection sqlConn;
        public WindowCheckVisit()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_menu(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string d;
                int id;
                id = Convert.ToInt32(boxID.Text);
                Data = new SqlDataAdapter("select dbo.patients.Name, dbo.patients.Surname, dbo.Visits.DateVisit, dbo.doctors.Name, dbo.doctors.Surname, dbo.Diagnosis.Diagnosis, dbo.Visits.SickList1, dbo.Visits.SickList2, dbo.Visits.Сomplaints, dbo.Medicine.medicine, dbo.Prescription.Notice from dbo.Visits left join dbo.patients on dbo.patients.IDpatient = dbo.Visits.IDpatient left join dbo.doctors on dbo.doctors.IDdoctor = dbo.Visits.IDdoctor left join dbo.Diagnosis on dbo.Diagnosis.IDdiagnosis = dbo.Visits.Diagnosis left join dbo.Prescription on dbo.Prescription.IDprescription = dbo.Visits.IDvisit left join dbo.Medicine on dbo.Prescription.IDmed = dbo.Medicine.IDmed where IDVisit = " + id, sqlConn);
                dT1 = new DataTable("patients");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < 11; i++)
                    {
                        d = (dT1.Rows[0][i]).ToString();
                        InfoPat.Text += d;
                        //d = (dT1.Rows[0][1]).ToString();
                        //InfoPat.Text += d;
                        InfoPat.Text += "\n";
                    }
                InfoPat.Text += "\n";


                sqlConn.Close();
            }
        }

        private void button_click_clear(object sender, RoutedEventArgs e)
        {
            InfoPat.Text = "";
        }
    }
}
