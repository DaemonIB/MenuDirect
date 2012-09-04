using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirectTestSpike
{
    public class Chef : IComparable
    {
        public List<int> orders = new List<int>();
        public int cookID { get; set; }
        public String name { get; set; }
        public int orderLength;

        public Chef()
        {
            cookID = GetCookID();
            orderLength = orders.Count;
        }

        public int CompareTo(Object chef)
        {
            Chef theChef = (Chef)chef;
            return this.orderLength.CompareTo(theChef.orderLength);
        }

        //Get name
        //Tell database which cook is working.
        //Get orders from db with cook name.
        public void GetChefName(String name)
        {

        }

        public int GetCookID()
        {
            int id = 0;

            //Get cook id from database here.

            return id; //Returns the cooks id as an int for the cookid.
        }

        /**
         * A cook receives an Order.
         */
        public void AddOrder(int theOrder)
        {
            orders.Add(theOrder);
        }

        /**
         * Deletes the order when the cook is done.
         */
        public void DeleteOrder(int theOrder)
        {
            orders.Remove(theOrder);
        }
    }
}
