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
using System.Collections;
using System.Data.Entity;
using System.ComponentModel;

namespace ServerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Double totalPrice = 0.0;
        public List<product> theProducts = new List<product>();

        public void updateCategory(int catID, string newName)
        {
            MenuDirect db = new MenuDirect();

            Category editCategory = db.Categories.Single(u => u.categoryID == catID); //To edit user that matches the Username
            editCategory.categoryName = newName;
            db.SaveChanges();
        }

        public void updateProduct(string prodName, string newProdName, string newProductCategoryName, Decimal newProdPrice)
        {
            MenuDirect db = new MenuDirect();

            product editProduct = db.products.Single(u => u.prodName == prodName); //To edit user that matches the Username
            editProduct.prodCategoryName = newProductCategoryName;
            editProduct.prodName = newProdName;
            editProduct.prodPrice = newProdPrice;
            db.SaveChanges();
        }

        public MainWindow()
        {
            InitializeComponent();

            MenuDirect db = new MenuDirect();

            //itemsDataGrid.ItemsSource = new TestGridItems2<TestGridItem>();
            theProducts = (from prod in db.products
                          select prod).ToList();
            lst.ItemsSource = theProducts;
            this.DataContext = this;
        }

        //Auto generated
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServerUI.MenuDirectDataSet menuDirectDataSet = ((ServerUI.MenuDirectDataSet)(this.FindResource("menuDirectDataSet")));
            
            // Load data into the table Category. You can modify this code as needed.
            ServerUI.MenuDirectDataSetTableAdapters.CategoryTableAdapter menuDirectDataSetCategoryTableAdapter = new ServerUI.MenuDirectDataSetTableAdapters.CategoryTableAdapter();
            menuDirectDataSetCategoryTableAdapter.Fill(menuDirectDataSet.Category);
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            categoryViewSource.View.MoveCurrentToFirst();
            
            // Load data into the table product. You can modify this code as needed.
            ServerUI.MenuDirectDataSetTableAdapters.productTableAdapter menuDirectDataSetproductTableAdapter = new ServerUI.MenuDirectDataSetTableAdapters.productTableAdapter();
            menuDirectDataSetproductTableAdapter.Fill(menuDirectDataSet.product);
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            productViewSource.View.MoveCurrentToFirst();
        }

        private void catClick(object sender, RoutedEventArgs e)
        {
            MenuDirect db = new MenuDirect();
            List<List<string>> lsts = new List<List<string>>();
            BindingList<product> theProd = new BindingList<product>();

            var tempProduct =
                from p in db.products
                where p.prodCategoryName == (String)categoryDataGrid.SelectedItem
                select p;

            foreach (product a in tempProduct)
            {
                theProd.Add(a);
            }

            lst.ItemsSource = theProd;
        }

        private void item_Click(object sender, RoutedEventArgs e)
        {
            string senderName = sender.ToString();
            string sendName = senderName.Replace("System.Windows.Controls.Button: ", "");

            MenuDirect db = new MenuDirect();
            IEnumerable<product> productList = (IEnumerable<product>)db.products;

            foreach (product a in productList)
            {
                if (a.prodName == sendName)
                {
                    totalPrice += Convert.ToDouble(a.prodPrice);
                    theProducts.Add(a);
                }
            }

            orderTotalLabel.Content = "Order Total: " + totalPrice.ToString();
        }

        private void send_click(object sender, RoutedEventArgs e)
        {
            using(MenuDirect db = new MenuDirect()) 
            {
                order addingOrder = new order()
                {
                    orderDelivered = false,
                    cookingCompleted = false
                };

                db.orders.Add(addingOrder);

                db.SaveChanges();

                orderList addingOrderList = new orderList()
                {
                    orderNumber = 0,
                    prodID = 1
                };

                db.orderLists.Add(addingOrderList);

                db.SaveChanges();
            }
        }

        private void categoryDataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(new RotateTransform(90));
            foreach (DataGridColumn dataGridColumn in categoryDataGrid.Columns)
            {
                if (dataGridColumn is DataGridTextColumn)
                {
                    DataGridTextColumn dataGridTextColumn = dataGridColumn as DataGridTextColumn;

                    Style style = new Style(dataGridTextColumn.ElementStyle.TargetType, dataGridTextColumn.ElementStyle.BasedOn);
                    style.Setters.Add(new Setter(Button.MarginProperty, new Thickness(0, 2, 0, 2)));
                    style.Setters.Add(new Setter(Button.LayoutTransformProperty, transformGroup));
                    style.Setters.Add(new Setter(Button.HorizontalAlignmentProperty, HorizontalAlignment.Center));

                    Style editingStyle = new Style(dataGridTextColumn.EditingElementStyle.TargetType, dataGridTextColumn.EditingElementStyle.BasedOn);
                    editingStyle.Setters.Add(new Setter(Button.MarginProperty, new Thickness(0, 2, 0, 2)));
                    editingStyle.Setters.Add(new Setter(Button.LayoutTransformProperty, transformGroup));
                    editingStyle.Setters.Add(new Setter(Button.HorizontalAlignmentProperty, HorizontalAlignment.Center));

                    dataGridTextColumn.ElementStyle = style;
                    dataGridTextColumn.EditingElementStyle = editingStyle;
                }
            }
            List<DataGridColumn> dataGridColumns = new List<DataGridColumn>();
            foreach (DataGridColumn dataGridColumn in categoryDataGrid.Columns)
            {
                dataGridColumns.Add(dataGridColumn);
            }
            categoryDataGrid.Columns.Clear();
            dataGridColumns.Reverse();
            foreach (DataGridColumn dataGridColumn in dataGridColumns)
            {
                categoryDataGrid.Columns.Add(dataGridColumn);
            }
        }

        private void categoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void productListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void categoryNameButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class TestGridItems2<T> : List<TestGridItem>
    {
    }

    public class TestGridItem
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
    }
}
