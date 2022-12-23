using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
using e_commerce_desktop.Model;
using MySqlConnector;

namespace e_commerce_desktop
{
    /// <summary>
    /// Logique d'interaction pour AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        MySqlConnection connection;
        MainWindow mainWindow;
        public AddProduct(MySqlConnection connection, MainWindow mainWindow)
        {
            InitializeComponent();
            this.connection = connection;
            this.mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string Productname = ProductName.Text;
            string publishers = Publishers.Text;
            string description = Descrption.Text;
            int price = Convert.ToInt32(Price.Text);
            int quantity = Convert.ToInt32(Quantity.Text);
            int Categoryid = Convert.ToInt32(CategoryId.Text);
            Products Productslist = new();
            Productslist.AddProduct(this.connection, Productname, price, quantity, publishers, Categoryid, description);
        }
    }
}
