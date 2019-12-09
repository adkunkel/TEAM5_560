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
            /*
            if (connection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Nope, Dont Do This");
                
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql;
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\initial_setup.sql");
                command = new SqlCommand(sql, connection);
                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
            }
            else
            {
                MessageBox.Show("Connect to the Database First");
            }*/

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string Keller = "John Keller ";
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql;
                    for (int i = 1; i < 501; i++)
                    {
                        sql = $"UPDATE Players.PlayerInfo " +
                            $"SET Name = N'{Keller}{ToRoman(i)}' " +
                            $"WHERE PlayerID = {i}" +
                            $"UPDATE Players.TeamPlayer " +
                            $"SET Name = N'{Keller}{ToRoman(i)}' " +
                            $"WHERE PlayerID = {i}";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = new SqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                    }
                    MessageBox.Show("Update Successful");
                }
                catch
                {
                    MessageBox.Show("Not Possible Now");
                }
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





        //FOR JK
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }
    }
}
