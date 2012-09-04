using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirectTestSpike
{
    public class Chef
    {
        List<order> orders = new List<order>();

        public Chef()
        {
            
        }

        /**
         * A cook receives an Order.
         */
        public void AddOrder(order theOrder)
        {
            orders.Add(theOrder);
        }

        /**
         * Deletes the order when the cook is done.
         */
        public void DeleteOrder(order theOrder)
        {
            orders.Remove(theOrder);
        }
    }
}
