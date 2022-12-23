using MySqlConnector;
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
using e_commerce_desktop.Model;

namespace e_commerce_desktop
{
    /// <summary>
    /// Logique d'interaction pour UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Page
    {
        MySqlConnection connection;
        MainWindow mainWindow;
        int Productid;
        public UpdateProduct(MySqlConnection connection,int Productid, MainWindow mainWindow)
        {
            this.connection = connection;
            this.Productid = Productid;
            this.mainWindow = mainWindow;
            InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Products Productslist = new();
            Product product = Productslist.GetProductById(Productid,this.connection);
            string Productname;
            int Categoryid;
            string publishers;
            string description;
            float price;
            int quantity;

            if (ProductName.Text != "") {
                Productname = ProductName.Text;
            } else
            {
                Productname = product.ProductName;
            }
            if (CategoryId.Text!= "")
            {
                Categoryid = Convert.ToInt32(CategoryId.Text);
            }
            else
            {
                Categoryid = product.CategoryId;
            }
            if (Publishers.Text!= "")
            {
                publishers = Publishers.Text;
            }
            else
            {
                publishers = product.Publishers;
            }
            if (Descrption.Text!= "")
            {
                description = Descrption.Text;
            }
            else
            {
                description= product.Description;
            }
            if (Price.Text!= "")
            {
                price = Convert.ToInt32(Price.Text);
            }
            else
            {
                price= product.Price;
            }
            if (Quantity.Text!= "")
            {
                quantity = Convert.ToInt32(Quantity.Text);
            }
            else
            {
                quantity= product.Quantity;
            }
    
            Productslist.UpdateProduct(connection, this.Productid, Productname, price, quantity, publishers, Categoryid, description);
            Productpage pg3 = new Productpage(connection,this.mainWindow);
            this.mainWindow.Content = pg3;

        }
    }
}
