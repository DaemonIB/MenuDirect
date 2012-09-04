using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections;

namespace AdminUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<string> ob
        {
            get {return _ob;}
        }
        private ObservableCollection<string> _ob = new ObservableCollection<string>();
        private DataGrid _currentDataGrid = new DataGrid();
        private ArrayList _selectedItems = new ArrayList();

        MenuDirectTestSpike.product theProduct = new MenuDirectTestSpike.product();
        MenuDirectTestSpike.Category theCategories = new MenuDirectTestSpike.Category();
        MenuDirectTestSpike.DatabaseSender theSender = new MenuDirectTestSpike.DatabaseSender();


        public MainWindow()
        {
            //FillObj();
            InitializeComponent();

            addProductDataGrid.ItemsSource = new TestGridItems2<TestGridItem>();
            addCategoryDataGrid.ItemsSource = new TestGridItems2<TestGridItem>();
            //updateProductDataGrid.ItemsSource = new TestGridItems2<TestGridItem>();

            updateProductDataGrid.ItemsSource = _selectedItems;
        }

        public void FillObj()
        {
            _ob = theSender.getCategoryList();
        }

        private void getAddButtonDataGrid(string currentTab)
        {
            if (currentTab == "Products")
            {
                _currentDataGrid = addProductDataGrid;
            }

            else if (currentTab == "Categories")
            {
                _currentDataGrid = addCategoryDataGrid;
            }
        }
        private void getUpdateButtonDataGrid(string currentTab)
        {
            if (currentTab == "Products")
            {
                _currentDataGrid = updateProductDataGrid;
            }

            else if (currentTab == "Categories")
            {
                _currentDataGrid = updateCategoryDataGrid;
            }
        }
        private void Check(object sender, RoutedEventArgs e)
        {
            _selectedItems.Add((product)mainDataGrid.SelectedItem);
        }
        private void Uncheck(object sender, RoutedEventArgs e)
        {
            _selectedItems.Remove((product)mainDataGrid.SelectedItem);
        }


        
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            getAddButtonDataGrid(databaseAdd.Content.ToString());
            _currentDataGrid.Visibility = System.Windows.Visibility.Visible;
            AddInput.Visibility = System.Windows.Visibility.Visible;   
        }
        private void acceptAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddInput.Visibility = System.Windows.Visibility.Collapsed;
            _currentDataGrid.Visibility = System.Windows.Visibility.Collapsed;

            String productName = "";
            Decimal price = 0.00M;
            String categoryName = "";

            for (int i = 0; i < Int64.MaxValue; i++)
            {
                TextBlock x = addProductDataGrid.Columns[0].GetCellContent(addProductDataGrid.Items[i]) as TextBlock;
                if (x != null)
                    if (!x.Text.Equals(""))
                    {
                        Console.WriteLine(x.GetType());
                        Console.WriteLine("Product " + i + ": " + x.Text);
                        productName = x.Text;
                    }
                    else
                    {
                        break;
                    }

                TextBlock y = addProductDataGrid.Columns[1].GetCellContent(addProductDataGrid.Items[i]) as TextBlock;
                if (y != null)
                    if (!y.Text.Equals(""))
                    {
                        Console.WriteLine("Price " + i + ": " + y.Text);
                        price = Convert.ToDecimal(y.Text);
                    }
                    else
                    {
                        break;
                    }

                TextBlock z = addProductDataGrid.Columns[2].GetCellContent(addProductDataGrid.Items[i]) as TextBlock;
                if (z != null)
                    if (!z.Text.Equals(""))
                    {
                        Console.WriteLine("Category " + i + ": " + z.Text);
                        categoryName = z.Text;
                    }
                    else
                    {
                        break;
                    }
                theSender.SendToDB(new MenuDirectTestSpike.product() { prodName = productName, prodPrice = price, prodCategoryName = categoryName });
            }
        }
        private void cancelAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddInput.Visibility = System.Windows.Visibility.Collapsed;
            _currentDataGrid.Visibility = System.Windows.Visibility.Collapsed;
        }



        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            //Needs to take the selected items from the initial display and delete them
        }



        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            _currentDataGrid.Items.Refresh();
            //Take items that were selected and place them on a grid table for the user to update
            getUpdateButtonDataGrid(databaseUpdate.Content.ToString());
            _currentDataGrid.Visibility = System.Windows.Visibility.Visible;
            UpdateInput.Visibility = System.Windows.Visibility.Visible;
            _currentDataGrid.ItemsSource = _selectedItems;
            
        }
        private void acceptUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInput.Visibility = System.Windows.Visibility.Collapsed;
            _currentDataGrid.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void cancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInput.Visibility = System.Windows.Visibility.Collapsed;
            _currentDataGrid.Visibility = System.Windows.Visibility.Collapsed;
        }


        


        private void cashOutButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void viewSalesButton_Click(object sender, RoutedEventArgs e)
        {

        }






        private System.Data.Objects.ObjectQuery<product> GetproductsQuery(MenuDirectEntities menuDirectEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<AdminUI.product> productsQuery = menuDirectEntities.products;
            // To explicitly load data, you may need to add Include methods like below:
            // productsQuery = productsQuery.Include("products.Category").
            // For more information, please see http://go.microsoft.com/fwlink/?LinkId=157380
            // Returns an ObjectQuery.
            return productsQuery;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AdminUI.MenuDirectEntities menuDirectEntities = new AdminUI.MenuDirectEntities();
            // Load data into products. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource productsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productsViewSource")));
            System.Data.Objects.ObjectQuery<AdminUI.product> productsQuery = this.GetproductsQuery(menuDirectEntities);
            productsViewSource.Source = productsQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
            // Load data into Categories. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource categoriesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoriesViewSource")));
            System.Data.Objects.ObjectQuery<AdminUI.Category> categoriesQuery = this.GetCategoriesQuery(menuDirectEntities);
            categoriesViewSource.Source = categoriesQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private System.Data.Objects.ObjectQuery<Category> GetCategoriesQuery(MenuDirectEntities menuDirectEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<AdminUI.Category> categoriesQuery = menuDirectEntities.Categories;
            // Returns an ObjectQuery.
            return categoriesQuery;
        }

        private void categoriesDataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
    }
}
