using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using e_commerce_desktop.Model;

namespace e_commerce_desktop
{
    // <summary>
    // Interaction logic for MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ConnectionDAO connectionDAO = new ConnectionDAO();
            var connection = connectionDAO.Connect("localhost", "root", "", "desktop");
            if (connection != null)
            {
                connection.Open();
                Products products = new Products();
                products.GetProducts(connection);
                Console.WriteLine(products.products);

            }
            

            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nom.Text;
            string mdp = mot_de_passe.Text;
            if (name == "root" && mdp == "")
            {
                Produit pg = new Produit(name, mdp);
                this.Content = pg;
            }
            else
            {
              //error.Text = "Identifiants incorrects";
            }
        }

    }
    }
