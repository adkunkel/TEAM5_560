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
    /// Interaction logic for QueryDatabase.xaml
    /// </summary>
    public partial class QueryDatabase : Page
    {
        private SqlConnection connection;
        public QueryDatabase(SqlConnection sqlConnection)
        {
            InitializeComponent();
            connection = sqlConnection;
        }
        /// <summary>
        /// Navigates to the ReportQuery page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ReportQueryButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new ReportQuery(connection));
        }
        /// <summary>
        /// Navigates to the NonReportQuery page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NonReportQueryButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new NonReportQuery(connection));
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
