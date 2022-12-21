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

namespace e_commerce_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                products.GetProducts(connection);
                Console.WriteLine(products.products);

            }
            

            InitializeComponent();
        }
    }
}
