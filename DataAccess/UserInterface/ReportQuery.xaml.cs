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
using System.Data;
using System.IO;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for ReportQuery.xaml
    /// </summary>
    public partial class ReportQuery : Page
    {
        private SqlConnection connection;

        private DataTable queryData;
        public ReportQuery(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }
        /// <summary>
        /// Populates the listbox with information from the given query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TopRankingButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql;
                try
                {
                    int week = Convert.ToInt32(Week.Text);
                    //CHANGE THIS TO THE REPORT QUERY
                    sql = $"select Top 10 tp.Name, p.Touchdowns, tg.Week, pi.Position, t.TeamName from Players.PlayerStats p " +
                        $"inner join Games.TeamGame tg on tg.TeamGameID = p.TeamGameID " +
                        $"inner join Players.TeamPlayer tp on tp.PlayerID = p.PlayerID " +
                        $"inner join Players.PlayerInfo pi on pi.PlayerID = tp.PlayerID " +
                        $"inner join NFL.Teams t on t.TeamID = tp.TeamID " +
                        $"where tg.Week = {week} Order by p.Touchdowns desc";
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    queryData = new DataTable();
                    queryData.Load(dataReader);
                    QueryData.ItemsSource = queryData.DefaultView;
                    command.Dispose();
                }
                catch
                {
                    MessageBox.Show("Insert a week between 1 and 17");
                }
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }
        /// <summary>
        /// Populates the listbox with information from the given query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TeamRosterButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql;
                string team = Team.Text;
                //CHANGE THIS TO THE REPORT QUERY
                sql = $"select t.TeamName, tp.Name, pi.Position, sum(ps.PassYards) as PassYards, sum(ps.RushYards) as RushYards, sum(ps.ReceivingYards) as ReceivingYards, " +
                    $"sum(ps.Receptions) as Receptions, sum(ps.Touchdowns) as Touchdowns, sum(ps.Interceptions) as Interceptions, sum(ps.Fumbles) as Fumbles " +
                    $"from NFL.Teams t " +
                    $"inner join Players.TeamPlayer tp on tp.TeamID = t.TeamID " +
                    $"inner join Players.PlayerInfo pi on pi.PlayerID = tp.PlayerID " +
                    $"left join Players.PlayerStats ps on ps.PlayerID = tp.PlayerID " +
                    $"where t.TeamName = '{team}' group by t.TeamName, tp.Name, pi.Position";
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                queryData = new DataTable();
                queryData.Load(dataReader);
                QueryData.ItemsSource = queryData.DefaultView;
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }
        /// <summary>
        /// Populates the listbox with information from the given query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SeasonDefStatsButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql;
                //CHANGE THIS TO THE REPORT QUERY
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\ReportQuery3.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                queryData = new DataTable();
                queryData.Load(dataReader);
                QueryData.ItemsSource = queryData.DefaultView;
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Open Connection First");
            }
        }
        /// <summary>
        /// Populates the listbox with information from the given query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SeasonKickerStatsButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql;
                //CHANGE THIS TO THE REPORT QUERY
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\ReportQuery4.sql");
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                queryData = new DataTable();
                queryData.Load(dataReader);
                QueryData.ItemsSource = queryData.DefaultView;
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
