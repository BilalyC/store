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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menu = sender as MenuItem;
            var menuValue = menu.Header.ToString();

            // Condition sur le nom des l'entêtes du menu
            switch (menuValue)
            {
                case "Catalogue":
                    display.Navigate(new System.Uri("catalog.xaml",
             UriKind.RelativeOrAbsolute));
                    break;
                case "Gestion":
                    display.Navigate(new System.Uri("stockGestion.xaml",
             UriKind.RelativeOrAbsolute));
                    break;
                case "Ajouter un produit":
                    display.Navigate(new System.Uri("addArticle.xaml",
             UriKind.RelativeOrAbsolute));
                    break;
            }
        }
    }
}
