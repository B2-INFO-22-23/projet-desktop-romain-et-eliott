using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace e_commerce_desktop
{
    // <summary>
    // Interaction logic for MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {

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
