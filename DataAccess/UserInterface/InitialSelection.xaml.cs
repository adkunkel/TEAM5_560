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
using FantasyData.Controller;

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
                    sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\initial_setup.sql");
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    InsertPlayerData();
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
                CloseConnection.Visibility = Visibility.Visible;
                OpenConnection.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Connection Already Open");
            }
        }






        /// <summary>
        /// Inserts the player stats.
        /// </summary>
        public void InsertPlayerData()
        {
            Controller controller = new Controller();
            controller.FillPlayerInfoArray(@"..\\..\\..\\GeneratedDataPlayerInfo.txt");
            controller.QuarterBackList(@"..\\..\\..\\GeneratedQBStats.txt");
            controller.RunningBackList(@"..\\..\\..\\GeneratedDataRBStats.txt");
            controller.WideReceiversList(@"..\\..\\..\\GeneratedDataWRStats.txt");
            controller.TightEndsList(@"..\\..\\..\\GeneratedDataTEStats.txt");
            controller.DefenseList(@"..\\..\\..\\DefensiveStats.txt");
            foreach (Player.PlayerInfo QB in controller.QuarterBacks)
            {
                for (int i = 0; i < QB.Stats.Count; i++)
                {
                    Player.QBRWTE p = QB.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + QB.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                }
            }
            foreach (Player.PlayerInfo RB in controller.RunningBacks)
            {
                for (int i = 0; i < RB.Stats.Count; i++)
                {
                    Player.QBRWTE p = RB.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + RB.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                }
            }
            foreach (Player.PlayerInfo WR in controller.WideReceivers)
            {
                for (int i = 0; i < WR.Stats.Count; i++)
                {
                    Player.QBRWTE p = WR.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + WR.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                }
            }
            foreach (Player.PlayerInfo TE in controller.TightEnds)
            {
                for (int i = 0; i < TE.Stats.Count; i++)
                {
                    Player.QBRWTE p = TE.Stats[i];
                    string sql = "INSERT Players.PlayerStats(PlayerID, PassYards, RushYards, ReceivingYards, Receptions, Touchdowns, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + TE.Name + ", " + p.PassYard + ", " + p.RushYard + ", " + p.ReceivingYards + ", " + p.Receptions + ", " + p.Touchdowns + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                }
            }
            foreach (Player.PlayerInfo DEF in controller.Defense)
            {
                for (int i = 0; i < DEF.DefStats.Count; i++)
                {
                    Player.Defense p = DEF.DefStats[i];
                    string sql = "INSERT Players.DefenseStats(PlayerID, PassYardsAllowed, RushYardsAllowed, TouchdownsAllowed, Safeties, Interceptions, Fumbles, TeamGameID, ByeWeek)\n" +
                        "VALUES (SELECT PI.PlayerID FROM Players.PlayerInfo PI WHERE PI.[NAME] = " + DEF.Name + ", " + p.PassYardsAllowed + ", " + p.RushYardsAllowed + ", " + p.Touchdowns + ", " + p.Safeties + ", " + p.Interceptions + ", " + p.Fumbles + ", " + p.GameID + ", " + p.ByeWeek + ") ";
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command = new SqlCommand(sql, connection);
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                }
            }
        }

    }
}
