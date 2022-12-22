using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using e_commerce_desktop.Model;
using System.Collections.Generic;

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
            var connection = connectionDAO.Connect("localhost", "root", "", "e-commerce");
            if (connection != null)
            {
                connection.Open();
                Products products = new Products();
                List<Product> products1 = products.GetProducts(connection);
                Product productTest = products.GetProductById(82272, connection);
                //products.AddProduct(connection, "test", 1, 30, "Wyatt Osinski", 80414, "Fuga odio veniam ex cupiditate. Saepe eum laborum ea ipsum sit deserunt. Quidem ullam voluptas aut qui ab sequi. Deleniti qui quidem quo assumenda neque ipsum. Harum dignissimos alias error sunt corrupti quo ullam provident. Architecto consequuntur veniam iste exercitationem. Voluptatem hic aut rerum non quasi. Facilis dolor incidunt omnis molestiae ducimus voluptatum. Eum quia non harum facilis pariatur. Rerum est et eum asperiores officiis. Commodi tempora soluta adipisci voluptatum aut consequatur quis. Facere et ipsam accusamus eius molestiae. Perspiciatis saepe accusantium vel dolorem.");
                Console.WriteLine(products1);
                //Console.WriteLine(productTest);

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
