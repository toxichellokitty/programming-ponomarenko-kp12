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
    /// Interaction logic for WindowAddPatient.xaml
    /// </summary>
    public partial class WindowAddPatient : Window
    {
        private static String Connection = @"Data Source=VLADYSLAVA\MSSQLSERVER01;Initial Catalog=db_hospital;Integrated Security=True";

        SqlDataAdapter Data;
        SqlDataAdapter Data2;
        SqlCommand Com;
        DataTable dT1;
        DataTable dT3;
        String strQ;
        SqlConnection sqlConn;

        public WindowAddPatient()
        {
            InitializeComponent();
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string d;
                Data = new SqlDataAdapter("SELECT IDpatient, Surname FROM db_hospital.dbo.patients order by Surname", sqlConn);
                dT1 = new DataTable("patients");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < dT1.Rows.Count - 1; i++)
                        PatientList.Items.Add(dT1.Rows[i][1].ToString() + " " + dT1.Rows[i][0].ToString());

                sqlConn.Close();
            }
        }

        public WindowAddPatient(string inputID)
        {
            InitializeComponent();
            PatientList.Text = inputID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            string pN = pName.Text;
            string pS = pSurname.Text;
            //int pA = ConpAge.Text);

            string command;
            //string[] findID = pSpeciality.Text.Split(' ');
            //Random rnd = new Random();
            //int num = rnd.Next(1000000,10000000);

            if (PatientList.Text == "")
            {
                int id;
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    DateTime dtnow = DateTime.Now;
                    Data2 = new SqlDataAdapter("select max(IDpatient) from db_hospital.dbo.patients", sqlConn);
                    dT3 = new DataTable("speciality");
                    Data2.Fill(dT3);
                    id = Convert.ToInt32(dT3.Rows[0][0]) + 1;
                    strQ = "INSERT INTO db_hospital.dbo.patients (IDpatient, Surname, Name, dtLastVisit, IDdiagnosis, IDdoctor, NumVisit, PatientAddress, Sex, Age, FirstDate, InsuranceNumber) VALUES('"+
                        id + "', '" + pSurname.Text + "', '" + pName.Text + "', '" + Convert.ToDateTime(dtnow) + 
                        "', '', '" + Convert.ToInt32(pDoc.Text) + "', '0', '" +
                        pAddress.Text + "', '" + pSex.Text + "', '" + Convert.ToInt32(pAge.Text) + 
                        "', '" + dtnow + "', '" + Convert.ToInt32(pNum.Text) + "')";
                    Com = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                }
            }

            else
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    string[] findID = PatientList.Text.Split(' ');
                    strQ = "update db_hospital.dbo.patients set Surname = '" + pSurname.Text + "', Name = '" + pName.Text + 
                        "', IDdoctor = '" + Convert.ToInt32(pDoc.Text) + 
                        "', PatientAddress = '" + pAddress.Text + 
                        "', Sex = '" + pSex.Text + "', Age = '" + pAge.Text + 
                        "', InsuranceNumber = '" + pNum.Text + "' where IDpatient = " + findID[1];
                    /*loh.Text = "update db_hospital.dbo.patients set Surname = '" + pSurname.Text + "', Name = '" + pName.Text +
                        "', IDdoctor = '" + Convert.ToInt32(pDoc.Text) +
                        "', PatientAddress = '" + pAddress.Text +
                        "', Sex = '" + pSex.Text + "', Age = '" + pAge.Text +
                        "', InsuranceNumber = '" + pNum.Text + "' where IDpatient = " + findID[1];*/
                    Com = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(Com.ExecuteNonQuery().ToString());

                }
            }

            sqlConn.Close();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (PatientList.Text != "")
            {
                string temp;
                int id;
                temp = PatientList.Text;
                string[] findID = temp.Split(' ');
                id = Convert.ToInt32(findID[1]);

                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    Data = new SqlDataAdapter("select Name, Surname, Sex, Age, PatientAddress, InsuranceNumber, IDdoctor from db_hospital.dbo.patients where IDpatient = " + id, sqlConn);
                    dT1 = new DataTable("patients");
                    Data.Fill(dT1);

                    pName.Text = (dT1.Rows[0][0]).ToString();
                    pSurname.Text = (dT1.Rows[0][1]).ToString();
                    pSex.Text = (dT1.Rows[0][2]).ToString();
                    pAge.Text = (dT1.Rows[0][3]).ToString();
                    pAddress.Text = (dT1.Rows[0][4]).ToString();
                    pNum.Text = (dT1.Rows[0][5]).ToString();
                    pDoc.Text = (dT1.Rows[0][6]).ToString();
                }
            }

            sqlConn.Close();
        }
    }
}
