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
//Allows for connection to database.
using System.Data.SqlClient;
using FantasyData.Models;
using System.IO;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for InitialSelection.xaml
    /// </summary>
    public partial class InitialSelection : Page
    {
        private SqlConnection connection;

        public InitialSelection()
        {
            InitializeComponent();
            string connectionString;
            connectionString = $"Data Source=mssql.cs.ksu.edu; Initial Catalog=Robbieo; User ID=Robbieo; Password=Database!";

            connection = new SqlConnection(connectionString);
            connection.Open();

            //Create Database Tables
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String sql;
                    sql = "SELECT * FROM NFL.Teams";
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
                catch
                {
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql;
                    sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\table_create.sql");
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    //MessageBox.Show(sql);
                    command.Dispose();
                    sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\initial_setup.sql");
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    //MessageBox.Show(sql);
                    command.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }

        public InitialSelection(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                CloseConnection.Visibility = Visibility.Hidden;
                OpenConnection.Visibility = Visibility.Visible;
            }
            else
            {
                CloseConnection.Visibility = Visibility.Visible;
                OpenConnection.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Navigates to the AlterDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AlterDatabaseButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new AlterDatabase(connection));
        }
        /// <summary>
        /// Navigates to the QueryDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void QueryDatabaseButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new QueryDatabase(connection));
        }
        /// <summary>
        /// Closes the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CloseConnectionButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Connection Closed");
                CloseConnection.Visibility = Visibility.Hidden;
                OpenConnection.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Connection Already Closed");
            }
        }
        /// <summary>
        /// Closes the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OpenConnectionButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                MessageBox.Show("Connection Opened");
                CloseConnection.Visibility = Visibility.Visible;
                OpenConnection.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Connection Already Open");
            }
        }
    }
}
