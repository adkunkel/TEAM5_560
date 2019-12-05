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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for DatabaseConnection.xaml
    /// </summary>
    public partial class DatabaseConnection : Page
    {
        private SqlConnection connection;

        public DatabaseConnection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Connect(object sender, EventArgs args)
        {
            string connectionString;
            string username = this.Username.Text;
            string password = this.Password.Password;
            if(username == "")
            {
                username = "Robbieo";
                password = "Database!";
            }
            connectionString = $"Data Source=mssql.cs.ksu.edu; Initial Catalog={username}; User ID={username}; Password={password}";
            
            connection = new SqlConnection(connectionString);
            connection.Open();
            MessageBox.Show("Connection Open");
            NavigationService.Navigate(new InitialSelection(connection));
            //connection.Close();
        }
    }
}
