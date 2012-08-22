using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MenuDirect
{

    public class Item
    {
        public String _itemName { get; set; }
        public double _itemPrice { get; set; }

        public Item(String itemName, double itemPrice)
        {
            _itemName = itemName;
            _itemPrice = itemPrice;
        }

   //     public Item(SerializationInfo info, StreamingContext ctxt)
   //{
   //   _itemName = (string)info.GetValue("Item Name", typeof(string));
   //   _itemPrice = (double)info.GetValue("Item Price",typeof(double));
   //}

   //public void GetItemData(SerializationInfo info, StreamingContext ctxt)
   //{
   //   info.AddValue("Item Name", _itemName);
   //   info.AddValue("Item Price", _itemPrice);
   //}

        public override string ToString()
        {
            return "Item Name: " + _itemName + "     Item Price: " + _itemPrice;
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
