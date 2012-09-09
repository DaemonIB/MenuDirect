using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AdminUI
{
    public class DatabaseSender : iSendable<product>
    {
        BindingList<string> _ob = new BindingList<string>();
        public BindingList<string> ob
        {
            get { return _ob; }
        }

        /**
      * Send Item to database.
      */
        public void SendToDB(product item)
        {
            using (var db = new MenuDirectEntities())
            {
                var newProduct = new product
                {
                    prodName = item.prodName,
                    prodPrice = item.prodPrice,
                    prodCategoryName = item.prodCategoryName
                };

                db.products.AddObject(newProduct);
                db.SaveChanges();
            }
        }

        //This is used in MainWindow adding category
        public void SendToDB(Category item)
        {
            using (MenuDirectEntities db = new MenuDirectEntities())
            {
                var newCategory = new Category
                {
                    categoryName = item.categoryName
                };

                db.Categories.AddObject(newCategory);
                db.SaveChanges();
            }
        }

        //This is used in MainWindow adding category
        public void updateDB(int updateItem, String item)
        {
            using (MenuDirectEntities db = new MenuDirectEntities())
            {
                db.Categories.First(p => p.categoryID == updateItem).categoryName = item;

                db.SaveChanges();
            }
        }

        //This is used in MainWindow adding category
        public void updateDB(product updateItem, product item)
        {
            using (MenuDirectEntities db = new MenuDirectEntities())
            {
                db.products.First(p => p.prodID == updateItem.prodID).prodName = item.prodName;
                db.products.First(p => p.prodID == updateItem.prodID).prodPrice = item.prodPrice;
                db.products.First(p => p.prodID == updateItem.prodID).prodCategoryName = item.prodCategoryName;

                db.SaveChanges();
            }
        }


        public BindingList<string> getCategoryList()
        {
            using (var db = new MenuDirectEntities())
            {
                foreach (Category theCategory in db.Categories)
                {
                    _ob.Add(theCategory.categoryName);
                }

                return _ob;
            }
        }

        /**
         * 
         */
        public void DeleteitemProduct()
        {

        }
    }
}