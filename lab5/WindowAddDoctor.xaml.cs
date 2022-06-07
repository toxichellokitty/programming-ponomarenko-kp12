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
    /// Interaction logic for WindowAddDoctor.xaml
    /// </summary>
    public partial class WindowAddDoctor : Window
    {
        private static String Connection = @"Data Source=VLADYSLAVA\MSSQLSERVER01;Initial Catalog=db_hospital;Integrated Security=True";

        SqlDataAdapter Data;
        SqlDataAdapter Data1;
        SqlDataAdapter Data2;
        SqlCommand Com;
        DataTable dT1;
        DataTable dT2;
        DataTable dT3;
        String strQ;
        SqlConnection sqlConn;

        public WindowAddDoctor()
        {
            InitializeComponent();
            if (DoctorList.Text != "")
            {
                string temp;
                int id;
                temp = DoctorList.Text;
                string[] findID = temp.Split(' ');
                id = Convert.ToInt32(findID[1]);

                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    Data = new SqlDataAdapter("select dbo.doctors.Name, dbo.doctors.Surname, dbo.doctors.IDspeciality, dbo.doctors.FirstWorkDay, dbo.doctors.Birthday from dbo.doctors where IDdoctor = " + id, sqlConn);
                    dT1 = new DataTable("doctors");
                    Data.Fill(dT1);

                    pName.Text = (dT1.Rows[0][0]).ToString();
                    pSurname.Text = (dT1.Rows[0][1]).ToString();
                    pSpeciality.Text = (dT1.Rows[0][2]).ToString();
                    pAge.Text = (dT1.Rows[0][3]).ToString();
                    pFirst.Text = (dT1.Rows[0][4]).ToString();
                }
            }
        }

        public WindowAddDoctor(string inputID)
        {
            InitializeComponent();
            DoctorList.Text = inputID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {

            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT IDdoctor, Surname FROM db_hospital.dbo.doctors where hired = 1 order by Surname", sqlConn);
                dT1 = new DataTable("doctors");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < dT1.Rows.Count - 1; i++)
                        DoctorList.Items.Add(dT1.Rows[i][1].ToString() + " " + dT1.Rows[i][0].ToString());

                
            }

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data1 = new SqlDataAdapter("SELECT IDspeciality, Speciality FROM db_hospital.dbo.Speciality order by IDspeciality", sqlConn);
                dT2 = new DataTable("speciality");
                Data1.Fill(dT2);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < dT2.Rows.Count - 1; i++)
                        pSpeciality.Items.Add(dT2.Rows[i][1].ToString() + " " + dT2.Rows[i][0].ToString());
            }

            sqlConn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            //string pN = pName.Text;
            //string pS = pSurname.Text;
            //int pA = ConpAge.Text);
            
            string command;
            string[] findID = pSpeciality.Text.Split(' ');

            if (DoctorList.Text == "")
            {
                int id;
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    Data2 = new SqlDataAdapter ("select max(IDdoctor) from db_hospital.dbo.doctors", sqlConn);
                    dT3 = new DataTable("speciality");
                    Data2.Fill(dT3);
                    id = Convert.ToInt32(dT3.Rows[0][0]) + 1;
                    strQ = "INSERT INTO db_hospital.dbo.doctors (IDdoctor, Surname, Name, IDspeciality, NumWork, FirstWorkDay, Birthday, Hired)  VALUES('" +
                        id + "', '" + pSurname.Text + "', '" + pName.Text + "', '" +
                        Convert.ToInt32(findID[1]) + "','0','" + Convert.ToDateTime(pFirst.Text) +
                        "', '" + Convert.ToDateTime(pAge.Text) + "', '1')";
                    Com = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                }
            }
            
            else
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    string[] IDdoc = DoctorList.Text.Split(' ');
                    strQ = "update db_hospital.dbo.doctors set Surname = '" + pSurname.Text + "', Name = '" +
                        pName.Text + "', IDspeciality = '" + Convert.ToInt32(findID[1]) + "', Birthday = '" +
                        Convert.ToDateTime(pAge.Text) + "', FirstWorkDay = '" + Convert.ToDateTime(pFirst.Text) +
                        "' where IDdoctor = " + IDdoc[1];
                    Com = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                }
            }

            sqlConn.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (DoctorList.Text != "")
            {
                string temp;
                int id;
                temp = DoctorList.Text;
                string[] findID = temp.Split(' ');
                id = Convert.ToInt32(findID[1]);

                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    Data = new SqlDataAdapter("select dbo.doctors.Name, dbo.doctors.Surname, dbo.doctors.IDspeciality, dbo.doctors.FirstWorkDay, dbo.doctors.Birthday from dbo.doctors where IDdoctor = " + id, sqlConn);
                    dT1 = new DataTable("doctors");
                    Data.Fill(dT1);

                    pName.Text = (dT1.Rows[0][0]).ToString();
                    pSurname.Text = (dT1.Rows[0][1]).ToString();
                    pSpeciality.Text = (dT1.Rows[0][2]).ToString();
                    pAge.Text = (dT1.Rows[0][3]).ToString();
                    pFirst.Text = (dT1.Rows[0][4]).ToString();
                }
            }

            sqlConn.Close();
        }
    }
}