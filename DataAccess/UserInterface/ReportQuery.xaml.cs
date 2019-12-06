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
    /// Interaction logic for ReportQuery.xaml
    /// </summary>
    public partial class ReportQuery : Page
    {
        private SqlConnection connection;
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
            //Query 1
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
        private void HomeButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new InitialSelection(connection));
        }
    }
}
