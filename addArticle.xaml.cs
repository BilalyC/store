using Microsoft.Win32;
using store;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour addArticle.xaml
    /// </summary>
    public partial class addArticle : Page
    {
        static StoreContext db;
        category selectedCategory;
        public addArticle()
        {
            db = new StoreContext();
            InitializeComponent();
            Categories.ItemsSource = db.category.ToList();
        }

        private void FindImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            //For any other formats
            of.Filter = "Fichiers d'image (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == true)
            {
                image.Text = of.FileName;
            }
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = ((ComboBox)sender);
            selectedCategory = combobox.SelectedItem as category;
        }

        private void CreateArticle(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            string regexName = @"^[A-Za-zéèàêâôûüïç\- ]+$";
            string regexDefinition = @"^[A-Za-zéèàêâôûüïç.,:?'\- ]+$";
            string regexReference = @"^[A-Za-z0-9]+$";

            // Vérification des TextBox : si la valeur est null, s'il est composé uniquement de chiffres et compris entre 2 limites
            // Vérification des ComboBox : si un objet a été choisi
            // Vérification du DatePicker : si une date a été choisie
            

            if (!String.IsNullOrEmpty(name.Text))
            {
                if (!Regex.IsMatch(name.Text, regexName))
                {
                    errorMessage += "Ecrire un nom valide\n";
                }
            }
            else
            {
                errorMessage += "Ecrire un nom\n";
            }

            if (String.IsNullOrEmpty(image.Text))
            {
                errorMessage += "Veuillez choisir une image\n";
            }

            if (!String.IsNullOrEmpty(description.Text))
            {
                if (!Regex.IsMatch(description.Text, regexDefinition))
                {
                    errorMessage += "Ecrire une description valide\n";
                }
            }
            else
            {
                errorMessage += "Ecrire une description\n";
            }

            if (selectedCategory == null)
            {
                errorMessage += "Choisissez une catégorie\n";
            }

            if (!String.IsNullOrEmpty(reference.Text))
            {
                if (!Regex.IsMatch(reference.Text, regexReference))
                {
                    errorMessage += "Ecrire une référence valide\n";
                }
            }
            else
            {
                errorMessage += "Ecrire une référence\n";
            }

            if (!String.IsNullOrEmpty(price.Text))
            {
                if (double.TryParse(price.Text, out double value))
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

            if (!String.IsNullOrEmpty(quantity.Text))
            {
                if (int.TryParse(quantity.Text, out int value))
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
                product productToAdd = new product();
                productToAdd.name = name.Text;
                productToAdd.image = File.ReadAllBytes(image.Text);
                productToAdd.description = description.Text;
                productToAdd.idCategory = selectedCategory.idCategory;
                productToAdd.reference = reference.Text;
                productToAdd.price = double.Parse(price.Text);
                productToAdd.quantity = int.Parse(quantity.Text);
                db.product.Add(productToAdd); // insertion dans la bdd
                db.SaveChanges(); // enregistre les changements
                MessageBox.Show("L'article a bien été ajouté dans la liste.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                name.Clear();
                image.Clear();
                description.Clear();
                Categories.SelectedIndex = -1;
                reference.Clear();
                price.Clear();
                quantity.Clear();
            }
            else
            {
                MessageBox.Show(errorMessage, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
