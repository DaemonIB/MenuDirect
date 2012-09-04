using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirectTestSpike
{
    public class DatabaseInserter
    {
        public void EnterItemToDB(String input)
        {
            using (var db = new MenuDirectEntities())
            {
                Random gen = new Random(DateTime.Now.Second);

                var newProduct = new product
                {
                    prodID = gen.Next(),
                    prodName = input,
                    prodPrice = Convert.ToDecimal(0.00),
                    prodCategoryName = "Food"
                };

                //IEnumerable<Category> theList = db.Categories;

                //foreach (Category a in theList)
                //{
                //    Console.WriteLine(a.categoryName);
                //}

                db.products.Add(newProduct);
                db.SaveChanges();
            }
        }
    }
}
