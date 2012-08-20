using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MenuDirect
{
    [Serializable()]

    class Item : ISerializable
    {
        public String _itemName { get; set; }
        public double _itemPrice { get; set; }

        public Item(String itemName, double itemPrice)
        {
            _itemName = itemName;
            _itemPrice = itemPrice;
        }

        public Item(SerializationInfo info, StreamingContext ctxt)
   {
      _itemname = (string)info.GetValue("Item Name", typeof(string));
      this.model = (string)info.GetValue("Model",typeof(string));
   }

   public void GetItemData(SerializationInfo info, StreamingContext ctxt)
   {
      info.AddValue("Make", this.make);
      info.AddValue("Model", this.model);
   }

        public override string ToString()
        {
            return "Item Name: " + _itemName + "     Item Price: " + _itemPrice;
        }
    }
}
