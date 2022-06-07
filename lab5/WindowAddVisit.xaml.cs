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
    /// Interaction logic for WindowAddVisit.xaml
    /// </summary>
    public partial class WindowAddVisit : Window
    {
        private static String Connection = @"Data Source=VLADYSLAVA\MSSQLSERVER01;Initial Catalog=db_hospital;Integrated Security=True";

        SqlDataAdapter Data;
        SqlDataAdapter Data2;
        SqlCommand Com;
        DataTable dT1;
        DataTable dT3;
        //String strQ;
        SqlConnection sqlConn;



        public WindowAddVisit()
        {
            InitializeComponent();
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                //patient
                Data = new SqlDataAdapter("SELECT IDpatient, Surname FROM db_hospital.dbo.patients order by Surname", sqlConn);
                dT1 = new DataTable("patients");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < dT1.Rows.Count - 1; i++)
                        PatientList.Items.Add(dT1.Rows[i][1].ToString() + " " + dT1.Rows[i][0].ToString());

                //doctor
                Data = new SqlDataAdapter("SELECT IDdoctor, Surname FROM db_hospital.dbo.doctors where hired = 1 order by Surname", sqlConn);
                dT1 = new DataTable("doctors");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < dT1.Rows.Count - 1; i++)
                        DoctorList.Items.Add(dT1.Rows[i][1].ToString() + " " + dT1.Rows[i][0].ToString());

                //діагноз
                Data = new SqlDataAdapter("SELECT IDdiagnosis, Diagnosis FROM db_hospital.dbo.diagnosis order by diagnosis", sqlConn);
                dT1 = new DataTable("diagnosis");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < dT1.Rows.Count - 1; i++)
                        DiagnosisList.Items.Add(dT1.Rows[i][1].ToString() + " " + dT1.Rows[i][0].ToString());

                sqlConn.Close();
            }



        }

        private void Button_Click_menu(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            string command;
            string[] findID = PatientList.Text.Split(' ');
            int idp, iddoc, idd;
            idp = Convert.ToInt32(findID[1]);
            findID = DoctorList.Text.Split(' ');
            iddoc = Convert.ToInt32(findID[1]);
            findID = DiagnosisList.Text.Split(' ');
            idd = Convert.ToInt32(findID[1]);
            Random rnd = new Random();
            DateTime dtnow = DateTime.Now;
            string strQ;
            

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                strQ = "INSERT INTO db_hospital.dbo.Visits (IDpatient, IDdoctor, DateVisit, Сomplaints, Diagnosis, SickList1, SickList2, IDvisit) VALUES('" +
                    idp + "', '" + iddoc + "', '" + dtnow + "', '" + vComplaints.Text + "', '" +
                    idd + "', '" + (DateTime)Sick1.SelectedDate + "', '" +
                    (DateTime)Sick2.SelectedDate + "', '" +
                    rnd.Next(1000000, 10000000) + "')";
                Com = new SqlCommand(strQ, sqlConn);
                if(Com.ExecuteNonQuery().ToString() == "1")
                {
                    MessageBox.Show("Запис успішно додано.");
                }
            }
            sqlConn.Close();

        }
    }
}
