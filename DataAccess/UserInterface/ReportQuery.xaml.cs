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
        private void DefenseButton(object sender, EventArgs args)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql;
                //CHANGE THIS TO THE REPORT QUERY
                sql = File.ReadAllText(@"..\\..\\..\\FantasyData\\SQL\\query1.sql");
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
        private void TouchdownButton(object sender, EventArgs args)
        {
            //Query 2
        }
        /// <summary>
        /// Populates the listbox with information from the given query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ExpertButton(object sender, EventArgs args)
        {
            //Query 3
        }
        /// <summary>
        /// Populates the listbox with information from the given query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void YardageButton(object sender, EventArgs args)
        {
            //Query 4
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
