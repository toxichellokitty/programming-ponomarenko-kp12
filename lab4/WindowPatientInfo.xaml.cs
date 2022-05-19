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
    /// Interaction logic for WindowPatientInfo.xaml
    /// </summary>
    public partial class WindowPatientInfo : Window
    {
        private static String Connection = @"Data Source=VLADYSLAVA\MSSQLSERVER01;Initial Catalog=db_hospital;Integrated Security=True";
      
        SqlDataAdapter Data;
        SqlCommand Com;
        DataTable dT1;
        String strQ;
        SqlConnection sqlConn;
        public WindowPatientInfo()
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
                Data = new SqlDataAdapter("SELECT Name, Surname, Sex, Age, PatientAddress, InsuranceNumber, FirstDate, NumVisit FROM dbo.patients WHERE IDpatient=" + id, sqlConn);
                dT1 = new DataTable("patients");
                Data.Fill(dT1);

                if (dT1.Rows.Count > 0)
                    for (int i = 0; i < 8; i++)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowAddPatient wap = new WindowAddPatient();
            Hide();
            wap.Show();
        }

        private void Button_Click_menu(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowCheckVisit wcv = new WindowCheckVisit();
            Hide();
            wcv.Show();
        }

        private void button_click_clear(object sender, RoutedEventArgs e)
        {
            InfoPat.Text = "";
        }
    }
}
