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
    /// Interaction logic for InitialSelection.xaml
    /// </summary>
    public partial class InitialSelection : Page
    {
        public InitialSelection()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Navigates to the AlterDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AlterDatabaseButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new AlterDatabase());
        }
        /// <summary>
        /// Navigates to the QueryDatabase page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void QueryDatabaseButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new QueryDatabase());
        }
    }
}
