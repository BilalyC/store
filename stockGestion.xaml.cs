using store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        product selectedProduct;
        category selectedCategory;

        public stockGestion()
        {
            db = new StoreContext();
            InitializeComponent();
            selectedProduct = new product();
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Products.ItemsSource = db.product.ToList();
        }

        private void product_selected(object sender, SelectionChangedEventArgs e)
        {
            if (Products.SelectedItem == null) return;
            selectedProduct = Products.SelectedItem as product;
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            nameProduct.Text = selectedProduct.name;
            DescProduct.Text = selectedProduct.description;
            Categories.ItemsSource = db.category.ToList();
            for (int i = 0; i < Categories.Items.Count; i++)
            {
                category tempCat = Categories.Items[i] as category;
                if (selectedProduct.idCategory == tempCat.idCategory)
                {
                    Categories.SelectedIndex = i;
                }
            }
            refProduct.Text = selectedProduct.reference;
            priceProduct.Text = selectedProduct.price.ToString();
            stockProduct.Text = selectedProduct.quantity.ToString();

            var ms = new MemoryStream(selectedProduct.image);
            var returnImage = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            image.Source = returnImage;
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            string regexName = @"^[A-Za-zéèàêâôûüïç\- ]+$";

            if (selectedProduct == null)
            {
                errorMessage += "Veuillez sélectionner une ligne à modifier\n";
            }
            else
            {
                if (!String.IsNullOrEmpty(nameProduct.Text))
                {
                    if (!Regex.IsMatch(nameProduct.Text, regexName))
                    {
                        errorMessage += "Ecrire un nom valide\n";
                    }
                }
                else
                {
                    errorMessage += "Ecrire un nom\n";
                }

                if (selectedCategory == null)
                {
                    errorMessage += "Choisissez une catégorie\n";
                }

                if (!String.IsNullOrEmpty(priceProduct.Text))
                {
                    if (double.TryParse(priceProduct.Text, out double value))
                    {
                        if (value <= 0)
                        {
                            errorMessage += "Le prix doit être positif\n";
                        }
                    }
                    else
                    {
                        errorMessage += "Le champ du prix ne doit être composé que de chiffres\n";
                    }
                }
                else
                {
                    errorMessage += "Ecrire un prix\n";
                }

                if (!String.IsNullOrEmpty(stockProduct.Text))
                {
                    if (int.TryParse(stockProduct.Text, out int value))
                    {
                        if (value <= 0)
                        {
                            errorMessage += "La quantité doit être positif\n";
                        }
                    }
                    else
                    {
                        errorMessage += "Le champ de la quantité ne doit être composé que de chiffres\n";
                    }
                }
                else
                {
                    errorMessage += "Ecrire une quantité en stock\n";
                }

                // S'il n'y a pas d'erreur, c'est à dire, si errorMessage est nul ou vide
                if (String.IsNullOrEmpty(errorMessage))
                {
                    // utilisation de MessageBoxResult qui verifie quel bouton l'utilisateur choisit
                    MessageBoxResult result = MessageBox.Show("Voulez-vous confirmer la modification ?", "Comfirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        selectedProduct.name = nameProduct.Text;
                        selectedProduct.idCategory = selectedCategory.idCategory;
                        selectedProduct.price = double.Parse(priceProduct.Text);
                        selectedProduct.quantity = int.Parse(stockProduct.Text);
                        // permettant la sauvegarde de la modification 
                        db.Entry(selectedProduct).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Le produit a bien été modifié dans la liste.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                        Products.ItemsSource = null;
                        Products.ItemsSource = db.product.ToList();

                        nameProduct.Text = " ";
                        DescProduct.Text = " ";
                        Categories.SelectedIndex = -1;
                        refProduct.Text = " ";
                        priceProduct.Text = " ";
                        stockProduct.Text = " ";
                        image.Source = null;
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous confirmer la supression ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.product.Remove(selectedProduct);
                    db.SaveChanges();
                    
                    MessageBox.Show("Le produit a bien été effacé de la liste.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                    // rafraichissement du DataGrid
                    Products.ItemsSource = null;
                    Products.ItemsSource = db.product.ToList();

                    // remise à zéro des champs
                    nameProduct.Text = " ";
                    DescProduct.Text = " ";
                    Categories.SelectedIndex = -1;
                    refProduct.Text = " ";
                    priceProduct.Text = " ";
                    stockProduct.Text = " ";
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer");
            }
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = ((ComboBox)sender);
            selectedCategory = combobox.SelectedItem as category;
        }
    }
}
