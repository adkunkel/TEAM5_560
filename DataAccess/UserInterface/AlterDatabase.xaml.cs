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
    /// Interaction logic for AlterDatabase.xaml
    /// </summary>
    public partial class AlterDatabase : Page
    {
        private SqlConnection connection;
        public AlterDatabase(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }

        /// <summary>
        /// Navigates to the PlayerInsert page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void InsertButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new InsertPlayer(connection));
        }
        /// <summary>
        /// Navigates to the PlayerUpdate page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void UpdateButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new UpdatePlayer(connection));
        }
        /// <summary>
        /// Reload the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ReloadButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Nope, Dont Do This");
                /*
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql;
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\initial_setup.sql");
                command = new SqlCommand(sql, connection);
                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();*/
            }
            else
            {
                MessageBox.Show("Connect to the Database First");
            }
        }
        /// <summary>
        /// Navigates to the InitialSelection page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void HomeButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new InitialSelection(connection));
        }

    }
}
