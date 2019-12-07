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
                    sql = $"INSERT Players.TeamPlayer(TeamID, Name) VALUES ((SELECT T.TeamID FROM NFL.Teams T WHERE T.TeamName = '{team}'), N'{name}')" +
                        $"INSERT Players.PlayerInfo(PlayerID, [Name], [Status], Height, [Weight], YearsPro, Position) " +
                        $"VALUES ((SELECT TP.PlayerID FROM Players.TeamPlayer TP WHERE TP.[Name] = '{name}'), N'{name}', N'Active', {height}, {weight}, 1, N'QB')";
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    MessageBox.Show("Insert Successful");
                    NavigationService.Navigate(new AlterDatabase(connection));
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
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
