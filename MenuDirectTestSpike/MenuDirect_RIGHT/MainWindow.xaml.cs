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
using System.ComponentModel;

namespace MenuDirect_RIGHT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ordering orders;
        List<product> displayed;
        int ordersPerChefMinimum;
        public int chefsCurrentOrderNum;
        public List<Chef> chefsList = new List<Chef>();
        public MenuDirectEntities db = new MenuDirectEntities();
        public List<order> listOfOrderNumbers;
        public int curChef = 0;

        public MainWindow()
        {
            orders = new ordering();

            try
            {
                InitializeComponent();

                chefsList.Add(new Chef() { cookID = 1, name = "billy bob" }); //hard coded a chef for now.

                //console.writeline("right before getactiveorders is called." + environment.newline);

                GetActiveOrders();  //needs to update everytime an order is added

                //console.writeline("right after getactiveorders is called." + environment.newline);


                //Needs to be scaled to EVERY ORDER
                MenuDirectEntities db = new MenuDirectEntities();

                //int num = chefsList.ElementAt(0).orders.ElementAt(0);

                List<int> IDList = getOrderListID(curChef);

                for (int i = 0; i < 1; i++)
                {
                    int num = IDList.ElementAt(i);

                    var prodIDs = (from ol in db.orderLists
                                   where ol.orderNumber == num
                                   select ol.prodID);

                    displayed = (from ol in db.products
                                 select ol).ToList<product>();

                    List<string> displayedLis = (from ol in displayed
                                     join prod in prodIDs on ol.prodID equals prod
                                     select ol.prodName).ToList<string>();

                    dataGrid1.ItemsSource = displayedLis;
                }

                //listBox1
                //listBox1.ItemsSource = displayed;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void categoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MenuDirectDataSet menuDirectDataSet = ((MenuDirectDataSet)(this.FindResource("menuDirectDataSet")));

            // Load data into the table product. You can modify this code as needed.
            MenuDirectDataSetTableAdapters.productTableAdapter menuDirectDataSetproductTableAdapter = new MenuDirectDataSetTableAdapters.productTableAdapter();
            menuDirectDataSetproductTableAdapter.Fill(menuDirectDataSet.product);
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            productViewSource.View.MoveCurrentToFirst();

            // Load data into the table orderList. You can modify this code as needed.
            MenuDirectDataSetTableAdapters.orderListTableAdapter menuDirectDataSetorderListTableAdapter = new MenuDirectDataSetTableAdapters.orderListTableAdapter();
            menuDirectDataSetorderListTableAdapter.Fill(menuDirectDataSet.orderList);
            System.Windows.Data.CollectionViewSource orderListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderListViewSource")));
            orderListViewSource.View.MoveCurrentToFirst();




            //listBox1.FontSize = 35;
            //prodNameListBox.FontSize = 35;

            // Load data into the table order. You can modify this code as needed.
            MenuDirectDataSetTableAdapters.orderTableAdapter menuDirectDataSetorderTableAdapter = new MenuDirectDataSetTableAdapters.orderTableAdapter();
            menuDirectDataSetorderTableAdapter.Fill(menuDirectDataSet.order);
            System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            orderViewSource.View.MoveCurrentToFirst();

            Console.WriteLine("End of window loaded");
            MenuDirect_RIGHT.MenuDirectEntities menuDirectEntities = new MenuDirect_RIGHT.MenuDirectEntities();
            // Load data into orderLists. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource orderListsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderListsViewSource")));
            System.Data.Objects.ObjectQuery<MenuDirect_RIGHT.orderList> orderListsQuery = this.GetorderListsQuery(menuDirectEntities);
            orderListsViewSource.Source = orderListsQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
            // Load data into the table Category. You can modify this code as needed.
            MenuDirect_RIGHT.MenuDirectDataSetTableAdapters.CategoryTableAdapter menuDirectDataSetCategoryTableAdapter = new MenuDirect_RIGHT.MenuDirectDataSetTableAdapters.CategoryTableAdapter();
            menuDirectDataSetCategoryTableAdapter.Fill(menuDirectDataSet.Category);
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            categoryViewSource.View.MoveCurrentToFirst();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private System.Data.Objects.ObjectQuery<orderList> GetorderListsQuery(MenuDirectEntities menuDirectEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<MenuDirect_RIGHT.orderList> orderListsQuery = menuDirectEntities.orderLists;
            // Returns an ObjectQuery.
            return orderListsQuery;
        }

        private List<int> getOrderListID(int ChefID)
        {
            return (from ch in db.orders
                    where ch.chefID == ChefID
                    select ch.orderNumber).ToList<int>();
        }

        /**
         * Adds an orderNumber to a list of order numbers.
         */
        public void GetActiveOrders()
        {
            using (MenuDirectEntities db = new MenuDirectEntities())
            {
                //Gets all unassigned orders
                listOfOrderNumbers = (from or in db.orders
                                           where or.chefID == null
                                           select or).ToList<order>();

                //Split up the chef's active orders
                ordersPerChefMinimum = listOfOrderNumbers.Count() / chefsList.Count; //Gets the number of orders divided by chefs.

                getChefOrders(0);
            }
        }

        public void getChefOrders(int chefID)
        {
            //Hard coded orders for chefs(Need to divide the orders evenly here).
            foreach (order orderN in listOfOrderNumbers)
            {
                int numOfOrders = (from or in db.orders
                                       where or.chefID == chefID
                                       select or).Count();

                if (numOfOrders < 4)
                {
                    (from or in db.orders where or.orderNumber == orderN.orderNumber select or).SingleOrDefault().chefID = chefID;
                    db.SaveChanges();
                    orderN.chefID = chefID;
                }
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
