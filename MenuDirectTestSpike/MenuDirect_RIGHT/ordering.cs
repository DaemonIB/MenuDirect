using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect_RIGHT
{
    public class ordering
    {
        //int ordersPerChefMinimum;
        //public int chefsCurrentOrderNum;
        //public List<Chef> chefsList = new List<Chef>();

        ///**
        // * Adds an orderNumber to a list of order numbers.
        // */
        //public void GetActiveOrders()
        //{
        //    using (MenuDirectEntities db = new MenuDirectEntities())
        //    {
        //        //Gets all unassigned orders
        //        List<int> listOfOrderNumbers = (from ordered in db.orders
        //                where ordered.isAssigned == false
        //                select ordered.orderNumber).ToList<int>();

        //        //Gets all the chefs, starting with the chef with the least amount of orders
        //        var sortedChefOrders = from sorts in chefsList
        //                               orderby sorts.orders.Count ascending
        //                               select sorts;

        //        //Split up the chef's active orders
        //        ordersPerChefMinimum = listOfOrderNumbers.Count() / chefsList.Count; //Gets the number of orders divided by chefs.

        //        bool isAssigned = false;

        //        //Hard coded orders for chefs(Need to divide the orders evenly here).
        //        foreach (int orderN in listOfOrderNumbers)
        //        {
        //            foreach (Chef chef in sortedChefOrders)
        //            {
        //                if (!isAssigned)
        //                {
        //                    int numOfOrders = chef.orders.Count;

        //                    if (numOfOrders <= ordersPerChefMinimum)
        //                    {
        //                        chef.orders.Add(orderN);
        //                        listOfOrderNumbers.Remove(orderN);
        //                        isAssigned = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //public List<String> DisplayOrder()
        //{
        //    List<String> allProductsInOrder = new List<String>();

        //    using (MenuDirectEntities db = new MenuDirectEntities())
        //    {
        //        foreach (Chef chef in chefsList)
        //        {
        //            if (chef.orders.Count > 0)
        //            {
        //                chefsCurrentOrderNum = chef.orders.ElementAt(0);
        //            }


        //            var displayed = from ol in db.orderLists
        //                            join prod in db.products on ol.prodID equals prod.prodID
        //                            where ol.orderNumber == chefsCurrentOrderNum
        //                            select prod.prodName;

        //            foreach (String productName in displayed)
        //            {
        //                allProductsInOrder.Add(Convert.ToString(productName));
        //                Console.WriteLine(Environment.NewLine + "DisplayOrder (adding productName to list): " + productName);
        //            }
        //        }
        //    }
        //    return allProductsInOrder;
        //}
    }
}
