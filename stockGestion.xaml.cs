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

        // Méthode se déclenchant quand on clique sur une ligne du DataGrid Products
        // S'active aussi après une modification ou suppression de produit
        private void product_selected(object sender, SelectionChangedEventArgs e)
        {
            // si l'instance renvoit un null, on sort de la méthode 
            if (Products.SelectedItem == null) return;
            selectedProduct = Products.SelectedItem as product; // affecte le contenu de la ligne sur une instance de product
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            nameProduct.Text = selectedProduct.name;
            DescProduct.Text = selectedProduct.description;
            // affectation des valeurs de la table category de la bdd dans le ComboBox
            Categories.ItemsSource = db.category.ToList();
            // boucle sur la sélection du ComboBox
            for (int i = 0; i < Categories.Items.Count; i++)
            {
                category tempCat = Categories.Items[i] as category;
                // Si les 2 id correspondent
                if (selectedProduct.idCategory == tempCat.idCategory)
                {
                    Categories.SelectedIndex = i; // Affichage de l'objet n°i du ComboBox
                }
            }
            refProduct.Text = selectedProduct.reference;
            priceProduct.Text = selectedProduct.price.ToString();
            stockProduct.Text = selectedProduct.quantity.ToString();

            var ms = new MemoryStream(selectedProduct.image); // création de flux de mémoire avec le tableau d'octets
            var returnImage = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad); // conversion permettant l'affichage de l'image
            image.Source = returnImage;
        }

        // Méthode gérent la modification d'un produit
        private void EditProduct(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            string regexName = @"^[A-Za-zéèàêâôûüïç\- ]+$";

            // si un produit a été choisi ou non
            if (selectedProduct == null)
            {
                errorMessage += "Veuillez sélectionner une ligne à modifier\n";
            }
            else
            {
                // Vérification du nom : si la valeur est null ou si elle correspond au regex
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

                // Vérification de l'instance de category : si elle a une valeur par rapport à son ComboBox

                if (selectedCategory == null)
                {
                    errorMessage += "Choisissez une catégorie\n";
                }

                // Vérification des numériques : si la valeur est null, s'il est composé uniquement de chiffres

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
                        image.Source = null;
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Méthode gérant la supression d'un produit
        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            // si une ligne a bien été choisie
            if (selectedProduct != null)
            {
                // utilisation de MessageBoxResult qui verifie quel bouton l'utilisateur choisit
                MessageBoxResult result = MessageBox.Show("Voulez-vous confirmer la supression ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // suppression du produit et sauvegarde du changement de la bdd
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

        // Méthode se déclenchant sur le choix d'un objet du ComboBox
        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = ((ComboBox)sender);
            selectedCategory = combobox.SelectedItem as category; // affecte le contenu de l'objet du ComboBox sur une instance de category
        }
    }
}
