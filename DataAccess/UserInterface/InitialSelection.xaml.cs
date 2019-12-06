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

        public InitialSelection(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }
        /// <summary>
        /// Navigates to the AlterDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AlterDatabaseButton(object sender, EventArgs args)
        {
            //NavigationService.Navigate(new AlterDatabase());
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
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + "\n";
                }
                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
            connection.Close();
        }
        /// <summary>
        /// Navigates to the QueryDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void QueryDatabaseButton(object sender, EventArgs args)
        {
            //NavigationService.Navigate(new QueryDatabase());
        }
    }
}
