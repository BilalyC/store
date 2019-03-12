using store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Logique d'interaction pour stockGestion.xaml
    /// </summary>
    public partial class stockGestion : Page
    {
        static StoreContext db;
        product productToAdd;
        int? idtodel;

        public stockGestion()
        {
            db = new StoreContext();
            InitializeComponent();
            productToAdd = new product();
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            products.ItemsSource = db.product.ToList();
        }

        private void product_selected(object sender, SelectionChangedEventArgs e)
        {
            if (products.SelectedItem == null) return;
            productToAdd = products.SelectedItem as product;
            idtodel = productToAdd.idProduct;
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            nameProduct.Text = productToAdd.name;
            DescProduct.Text = productToAdd.description;
            categorieProduct.Text = productToAdd.category.name;
            refProduct.Text = productToAdd.reference;
            priceProduct.Text = productToAdd.price.ToString();
            stockProduct.Text = productToAdd.quantity.ToString();

            var ms = new MemoryStream(productToAdd.image);
            var returnImage = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            image.Source = returnImage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // permettant la sauvegarde de la modification 
            db.Entry(productToAdd).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("la modification a bien été pris en compte");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.product.Remove(productToAdd);
            productToAdd = db.product.Find(idtodel);
            db.product.Remove(productToAdd);
            db.SaveChanges();
            products.ItemsSource = null;
            products.ItemsSource = db.product.ToList();
            MessageBox.Show("Ca marche");
            nameProduct.Text = " ";
            DescProduct.Text = " ";
            refProduct.Text = " ";
            priceProduct.Text = " ";
            stockProduct.Text = " ";
        }
    }
}
