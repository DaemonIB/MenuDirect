using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MenuDirectTestSpike;

namespace CookUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ordering orders = new ordering();

        public MainWindow()
        {
            InitializeComponent();
            MenuDirectTestSpike.Program.chefsList.Add(new Chef() { cookID = 1, name = "Billy Bob" }); //Hard coded a chef for now.
            
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            orders.GetActiveOrders();

            foreach(String productName in orders.DisplayOrder()) {
            listBox1.Items.Add(productName);
            }

            listBox1.FontSize = 35;

            OrderNumLabel.Content = "Order Number: " + orders.chefsCurrentOrderNum;
        }
    }
}
