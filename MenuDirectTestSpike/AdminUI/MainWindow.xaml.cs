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
using System.ComponentModel;
using System.Data;

//all if statements dealing with if category else not need to 
//be changed and the loops need to be minimized
namespace AdminUI
{
    public partial class MainWindow : Window
    {

        public BindingList<string> ob
        {
            get {return _ob;}
        }
        private BindingList<string> _ob = new BindingList<string>();
        private DataGrid _currentDataGrid = new DataGrid();
        private BindingList<product> _selectedProducts = new BindingList<product>();
        private BindingList<Category> _selectedCategories = new BindingList<Category>();
        BindingList<product> blankListProduct = new BindingList<product>();
        BindingList<Category> blankListCategory = new BindingList<Category>();
        private int tempCategoryID;
        private product tempProduct;

        
        product theProduct = new product();
        Category theCategories = new Category();
        DatabaseSender theSender = new DatabaseSender();


        public MainWindow()
        {
            InitializeComponent();

            addProductDataGrid.ItemsSource = new BindingList<TestGridItem>();
            addCategoryDataGrid.ItemsSource = new BindingList<TestGridItem>();

            updateProductDataGrid.ItemsSource = _selectedProducts;
            updateCategoryDataGrid.ItemsSource = _selectedCategories;
        }
        //Determines which datagrid to use SIMPLIFY
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

        //Assign code to checked and unchecked items (adds to lists)
        private void Check(object sender, RoutedEventArgs e)
        {
            _selectedProducts.Add((product)productDataGrid.SelectedItem);
        }
        private void Uncheck(object sender, RoutedEventArgs e)
        {
            _selectedProducts.Remove((product)productDataGrid.SelectedItem);
        }

        private void CheckCat(object sender, RoutedEventArgs e)
        {
            _selectedCategories.Add((Category)categoriesDataGrid.SelectedItem);
        }
        private void UncheckCat(object sender, RoutedEventArgs e)
        {
            _selectedCategories.Remove((Category)categoriesDataGrid.SelectedItem);
        }

        //Add button functionality (SIMPLIFY)
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
            MenuDirectEntities db = new MenuDirectEntities();
            BindingList<product> tempproduct = new BindingList<product>();
            BindingList<Category> tempCategory = new BindingList<Category>();

            if (databaseAdd.Content.ToString() == "Categories")
            {
                String catName = "";

                for (int i = 0; i < addCategoryDataGrid.Items.Count; i++)
                {
                    TextBlock x = addCategoryDataGrid.Columns[0].GetCellContent(addCategoryDataGrid.Items[i]) as TextBlock;
                    if (x != null)
                    {
                        if (!x.Text.Equals(""))
                        {
                            //Console.WriteLine(x.GetType());
                           // Console.WriteLine("Category " + i + ": " + x.Text);
                            catName = x.Text;
                        }
                        else
                        {
                            break;
                        }
                    }
                    theSender.SendToDB(new Category() { categoryName = catName});
                }


                    foreach (Category theT in db.Categories)
                    {
                        tempCategory.Add(theT);
                    }

                    categoriesDataGrid.ItemsSource = tempCategory;
                    addCategoryDataGrid.ItemsSource = new BindingList<TestGridItem>();

            }
            else
            {
                String productName = "";
                Decimal price = 0.00M;
                String categoryName = "";

                for (int i = 0; i < addProductDataGrid.Items.Count; i++)
                {
                    TextBlock x = addProductDataGrid.Columns[0].GetCellContent(addProductDataGrid.Items[i]) as TextBlock;
                    if (x != null)
                    {
                        if (!x.Text.Equals(""))
                        {
                           // Console.WriteLine(x.GetType());
                           // Console.WriteLine("Product " + i + ": " + x.Text);
                            productName = x.Text;
                        }
                        else
                        {
                            break;
                        }
                    }

                    TextBlock y = addProductDataGrid.Columns[1].GetCellContent(addProductDataGrid.Items[i]) as TextBlock;
                    if (y != null)
                    {
                        if (!y.Text.Equals(""))
                        {
                           // Console.WriteLine("Price " + i + ": " + y.Text);
                            price = Convert.ToDecimal(y.Text);
                        }
                        else
                        {
                            break;
                        }
                    }

                    TextBlock z = addProductDataGrid.Columns[2].GetCellContent(addProductDataGrid.Items[i]) as TextBlock;
                    if (z != null)
                    {
                        if (!z.Text.Equals(""))
                        {
                            //Console.WriteLine("Category " + i + ": " + z.Text);
                            categoryName = z.Text;
                        }
                        else
                        {
                            break;
                        }
                    }
                    theSender.SendToDB(new product() { prodName = productName, prodPrice = price, prodCategoryName = categoryName });
                }

                foreach (product theT in db.products)
                {
                    tempproduct.Add(theT);
                }

                productDataGrid.ItemsSource = tempproduct;
                addProductDataGrid.ItemsSource = new BindingList<TestGridItem>();
            }
        }
        private void cancelAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddInput.Visibility = System.Windows.Visibility.Collapsed;
            _currentDataGrid.Visibility = System.Windows.Visibility.Collapsed;
        }

        //delete button functionality 
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (databaseUpdate.Content.ToString() == "Categories")
            {
                deleteStuff(_selectedCategories);
            }
            else
            {
                deleteStuff(_selectedProducts);
            }
        }
        //SIMPLIFY
        public void deleteStuff<T>(BindingList<T> theList)
        {
            MenuDirectEntities db = new MenuDirectEntities();

            if (databaseUpdate.Content.ToString() == "Categories")
            {
                BindingList<Category> tempCategory = new BindingList<Category>();

                foreach (Category theT in db.Categories)
                {
                    tempCategory.Add(theT);
                }

                foreach (Category theT in _selectedCategories)
                {
                    db.Categories.DeleteObject(db.Categories.First(p => p.categoryName == theT.categoryName));
                    tempCategory.Remove(db.Categories.First(p => p.categoryName == theT.categoryName));
                }

                _selectedCategories.Clear();
                categoriesDataGrid.ItemsSource = tempCategory;
            }

            else
            {
                BindingList<product> tempproduct = new BindingList<product>();

                foreach (product theT in db.products)
                {
                    tempproduct.Add(theT);
                }

                foreach (product theT in _selectedProducts)
                {
                    db.products.DeleteObject(db.products.First(p => p.prodID == theT.prodID));
                    tempproduct.Remove(db.products.First(p => p.prodID == theT.prodID));
                }
                _selectedProducts.Clear();
                productDataGrid.ItemsSource = tempproduct;
            }
            db.SaveChanges();
        }

        //Update button functionality
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            getUpdateButtonDataGrid(databaseUpdate.Content.ToString());
            _currentDataGrid.Visibility = System.Windows.Visibility.Visible;
            UpdateInput.Visibility = System.Windows.Visibility.Visible;

            if (databaseUpdate.Content.ToString() == "Categories")
            {
                _currentDataGrid.ItemsSource = _selectedCategories;
            }
            else
                _currentDataGrid.ItemsSource = _selectedProducts;
        }
            
             
        private void acceptUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInput.Visibility = System.Windows.Visibility.Collapsed;
            _currentDataGrid.Visibility = System.Windows.Visibility.Collapsed;

            MenuDirectEntities db = new MenuDirectEntities();
            BindingList<product> tempproduct = new BindingList<product>();
            BindingList<Category> tempCategory = new BindingList<Category>();


            if (databaseUpdate.Content.ToString() == "Categories")
            {
                String catName = "";

                for (int i = 0; i < updateCategoryDataGrid.Items.Count; i++)
                {
                    TextBlock x = updateCategoryDataGrid.Columns[0].GetCellContent(updateCategoryDataGrid.Items[i]) as TextBlock;
                    if (x != null)
                    {
                        if (!x.Text.Equals(""))
                        {
                            // Console.WriteLine(x.GetType());
                            // Console.WriteLine("Category " + i + ": " + x.Text);
                            catName = x.Text;
                        }
                        else
                        {
                            break;
                        }
                    }

                    tempCategoryID = _selectedCategories[i].categoryID;
                    theSender.updateDB(tempCategoryID, catName);
                }

                updateCategoryDataGrid.ItemsSource = _selectedCategories;
            }

            else
            {
                String productName = "";
                Decimal price = 0.00M;
                String categoryName = "";

                for (int i = 0; i < updateProductDataGrid.Items.Count; i++)
                {
                    TextBlock x = updateProductDataGrid.Columns[0].GetCellContent(updateProductDataGrid.Items[i]) as TextBlock;
                    if (x != null)
                    {
                        if (!x.Text.Equals(""))
                        {
                            // Console.WriteLine(x.GetType());
                            // Console.WriteLine("Product " + i + ": " + x.Text);
                            productName = x.Text;
                        }
                        else
                        {
                            break;
                        }
                    }

                    TextBlock y = updateProductDataGrid.Columns[1].GetCellContent(updateProductDataGrid.Items[i]) as TextBlock;
                    if (y != null)
                    {
                        if (!y.Text.Equals(""))
                        {
                            // Console.WriteLine("Price " + i + ": " + y.Text);
                            price = Convert.ToDecimal(y.Text);
                        }
                        else
                        {
                            break;
                        }
                    }

                    TextBlock z = updateProductDataGrid.Columns[2].GetCellContent(updateProductDataGrid.Items[i]) as TextBlock;
                    if (z != null)
                    {
                        if (!z.Text.Equals(""))
                        {
                            //Console.WriteLine("Category " + i + ": " + z.Text);
                            categoryName = z.Text;
                        }
                        else
                        {
                            break;
                        }
                    }
                    tempProduct = _selectedProducts[i];
                    product instanceProduct = new product() { prodName = productName, prodPrice = price, prodCategoryName = categoryName };
                    theSender.updateDB(tempProduct, instanceProduct);
                }

                updateProductDataGrid.ItemsSource = _selectedProducts;
            }
            
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

            System.Data.Objects.ObjectQuery<product> productsQuery = menuDirectEntities.products;
            // To explicitly load data, you may need to add Include methods like below:
            // productsQuery = productsQuery.Include("products.Category").
            // For more information, please see http://go.microsoft.com/fwlink/?LinkId=157380
            // Returns an ObjectQuery.
            return productsQuery;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            MenuDirectEntities menuDirectEntities = new MenuDirectEntities();
            // Load data into products. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource productsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productsViewSource")));
            System.Data.Objects.ObjectQuery<product> productsQuery = this.GetproductsQuery(menuDirectEntities);
            productsViewSource.Source = productsQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
            // Load data into Categories. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource categoriesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoriesViewSource")));
            System.Data.Objects.ObjectQuery<Category> categoriesQuery = this.GetCategoriesQuery(menuDirectEntities);
            categoriesViewSource.Source = categoriesQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private System.Data.Objects.ObjectQuery<Category> GetCategoriesQuery(MenuDirectEntities menuDirectEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<Category> categoriesQuery = menuDirectEntities.Categories;
            // Returns an ObjectQuery.
            return categoriesQuery;
        }

        private void categoriesDataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class TestGridItem
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
    }
}
