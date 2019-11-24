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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AlterDatabase.xaml
    /// </summary>
    public partial class AlterDatabase : Page
    {
        public AlterDatabase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the PlayerInser page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void InsertButton(object sender, EventArgs args)
        {

        }
        /// <summary>
        /// Navigates to the PlayerUpdate page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void UpdateButton(object sender, EventArgs args)
        {

        }
        /// <summary>
        /// Navigates to the InitialSelection page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void HomeButton(object sender, EventArgs args)
        {
            NavigationService.Navigate(new InitialSelection());
        }

    }
}
