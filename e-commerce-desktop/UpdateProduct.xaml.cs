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
            Productslist.GetProductById(Productid,this.connection);
            string Productname = ProductName.Text;
            int Categoryid = Convert.ToInt32(CategoryId.Text);
            string publishers = Publishers.Text;
            string description = Descrption.Text;
            int price = Convert.ToInt32(Price.Text);
            int quantity = Convert.ToInt32(Quantity.Text);
            Productslist.UpdateProduct(connection, this.Productid, Productname, price, quantity, publishers, Categoryid, description);
            Productpage pg3 = new Productpage(connection,this.mainWindow);
            this.mainWindow.Content = pg3;

        }
    }
}
