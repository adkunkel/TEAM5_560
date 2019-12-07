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
using System.Data.SqlClient;
using System.IO;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for NonReportQuery.xaml
    /// </summary>
    public partial class NonReportQuery : Page
    {
        private SqlConnection connection;
        public NonReportQuery(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }
        /// <summary>
        /// NonReportQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OneButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query1.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(1) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// NonReportQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TwoButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query2.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// NonReportQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ThreeButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query3.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " " + dataReader.GetValue(1) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// NonReportQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FourButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query4.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// NonReportQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FiveButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query5.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// NonReportQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SixButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query6.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// Navigates to the InitialSelection page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BackButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new QueryDatabase(connection));
        }
    }
}
