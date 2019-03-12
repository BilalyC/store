using store;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour catalog.xaml
    /// </summary>
    public partial class catalog : Page
    {
        static StoreContext db;
        product productToAdd;
        int? idtodel;

        public catalog()
        {
            db = new StoreContext();
            InitializeComponent();
            products.ItemsSource = db.product.ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //rien rien. 
        }

        private void product_selected(object sender, SelectionChangedEventArgs e)
        {
            if (products.SelectedItem == null) return;
            productToAdd = products.SelectedItem as product;
            idtodel = productToAdd.idProduct;
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            nameProduct.Text = productToAdd.name;
            descProduct.Text = productToAdd.description;
            refProduct.Text = productToAdd.reference;
            priceProduct.Text = productToAdd.price.ToString();
            stockProduct.Text = productToAdd.quantity.ToString();

            var ms = new MemoryStream(productToAdd.image);
            var returnImage = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            image.Source = returnImage;
        }
    }
}
