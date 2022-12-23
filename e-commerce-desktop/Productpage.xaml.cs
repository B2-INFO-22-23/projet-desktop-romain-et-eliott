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

namespace e_commerce_desktop
{
    public partial class Productpage : Page
    {
        MySqlConnection connection;


        public Productpage(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            Products Productslist = new();
            var product = Productslist.GetProducts(this.connection);
            for (int i = 0; i < product.Count; i++)
            {
                produits.ItemsSource = product;
            }

        }
    }
}