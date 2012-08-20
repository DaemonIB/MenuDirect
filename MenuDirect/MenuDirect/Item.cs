using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    class Item
    {
        public List<String> itemsAvailable{ get; set; }
        public String _itemName { get; set; }
        public double _itemPrice { get; set; }

        public Item(String itemName, double itemPrice)
        {
            _itemName = itemName;
            _itemPrice = itemPrice;
        }

        public void ChooseItem()
        {
            
        }

        public override string ToString()
        {
            return "Item Name: " + _itemName + "     Item Price: " + _itemPrice;
        }
    }
}
