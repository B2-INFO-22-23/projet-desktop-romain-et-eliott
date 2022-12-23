using e_commerce_desktop.Model;
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
using e_commerce_desktop;
using MySqlConnector;
using System.Data;
using System.Security.Policy;
using System.Diagnostics;

namespace e_commerce_desktop
{
    public partial class Productpage : Page
    {
        MySqlConnection connection;
        MainWindow mainWindow;

        public Productpage(MySqlConnection connection,MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow= mainWindow;
            this.connection = connection;
            Products Productslist = new();
            var product = Productslist.GetProducts(this.connection);
            for (int i = 0; i < product.Count; i++)
            {
                produits.ItemsSource = product;
            }

        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ProductId.Text!= "") {
                int Productid = Convert.ToInt32(ProductId.Text);
                //var erreur = Erreur.Content;
                Products Productslist = new();
                Productslist.DeleteProduct(this.connection, Productid);
                var product = Productslist.GetProducts(this.connection);
                for (int i = 0; i < product.Count; i++)
                {
                    produits.ItemsSource = product;
                }
                if (Productslist != null)
                {
                    //erreur =" Suprression Terminé";
                }
                else
                {
                    //erreur = "Echec de la suppression";
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProduct pg2 = new AddProduct(connection,this.mainWindow);
            this.mainWindow.Content = pg2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ProductId2.Text != "")
            {
                int Productid = Convert.ToInt32(ProductId2.Text);
                Products Productslist = new();
                if (Productslist.GetProductById(Productid, connection).ProductName != null)
                {
                    UpdateProduct pg3 = new UpdateProduct(connection, Productid, this.mainWindow);
                    this.mainWindow.Content = pg3;
                }
            }
            
            
        }
    }
}