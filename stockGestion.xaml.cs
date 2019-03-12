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

namespace magasin
{
    /// <summary>
    /// Logique d'interaction pour stockGestion.xaml
    /// </summary>
    public partial class stockGestion : Page
    {
        public stockGestion()
        {
            InitializeComponent();
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            //appointDataGrid.ItemsSource = db.appointments.ToList();
            //editComboboxCustomer.ItemsSource = db.customers.ToList();
            //editComboboxBroker.ItemsSource = db.brokers.ToList();
        }
    }
}
