using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{

    public class Item
    {
        public String _itemName { get; set; } //Defines the item name.
        public double _itemPrice { get; set; } //Defines the item price.

        public Item(String itemName, double itemPrice)
        {
            _itemName = itemName;
            _itemPrice = itemPrice;
        }


        /**
         * Overrode the ToString to read an Item object easier.
         */
        public override string ToString()
        {
            return "Item Name: " + _itemName + "     Item Price: " + _itemPrice;
        }
    }
}
