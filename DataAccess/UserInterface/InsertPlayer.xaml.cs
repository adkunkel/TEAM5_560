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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for InsertPlayer.xaml
    /// </summary>
    public partial class InsertPlayer : Page
    {
        private SqlConnection connection;
        public InsertPlayer(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }

        /// <summary>
        /// Inserts the player into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void InsertButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                /*
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql;
                sql = $"INSERT INTO Clubs.Club(Name, Purpose) VALUES('Demo', 'The Demo is Inserting Correctly')";
                command = new SqlCommand(sql, connection);
                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Insert Successful");
                NavigationService.Navigate(new AlterDatabase(connection));*/
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }

        /// <summary>
        /// Navigates to the AlterDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CancelButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new AlterDatabase(connection));
        }
    }
}
