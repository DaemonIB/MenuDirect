using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MenuDirectTestSpike
{
    public class DatabaseSender : iSendable<product>
    {
        ObservableCollection<string> _ob = new ObservableCollection<string>();
        public ObservableCollection<string> ob
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
                Random gen = new Random(DateTime.Now.Second);

                var newProduct = new product
                {
                    prodID = gen.Next(),
                    prodName = item.prodName,
                    prodPrice = item.prodPrice,
                    prodCategoryName = item.prodCategoryName
                };

                db.products.Add(newProduct);
                db.SaveChanges();
            }
        }


        public ObservableCollection<string> getCategoryList()
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
