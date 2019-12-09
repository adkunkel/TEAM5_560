using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for UpdatePlayer.xaml
    /// </summary>
    public partial class UpdatePlayer : Page
    {
        private SqlConnection connection;
        public UpdatePlayer(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }

        /// <summary>
        /// Inserts the player into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void UpdateButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string name = PlayerName.Text;
                    int height = Convert.ToInt32(Height.Text);
                    int weight = Convert.ToInt32(Weight.Text);
                    string position = Position.SelectionBoxItem.ToString();
                    string team = Team.SelectionBoxItem.ToString();

                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql;
                    sql = $"UPDATE Players.PlayerInfo " +
                        $"SET Weight = {weight}, Height = {height}, Position = N'{position}' " +
                        $"WHERE Name = N'{name}' " +
                        $"UPDATE Players.TeamPlayer " +
                        $"SET TeamID = (SELECT Team.TeamID FROM NFL.Teams AS Team WHERE Team.TeamName = '{team}') " +
                        $"WHERE PlayerID = (SELECT Player.PlayerID FROM Players.PlayerInfo AS Player WHERE Player.Name = '{name}')";
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    MessageBox.Show("Update Successful");
                    NavigationService.Navigate(new AlterDatabase(connection));
                }
                catch
                {
                    MessageBox.Show("Invalid Input. Player name must match name in the database.");
                }
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
