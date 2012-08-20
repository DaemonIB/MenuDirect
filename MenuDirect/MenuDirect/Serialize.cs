using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MenuDirect
{
    

    public class Serializer
    {
        public Serializer()
        {
        }

        public void SerializeObject(string filename, Item itemToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, itemToSerialize);
            stream.Close();
        }

        public Item DeSerializeObject(string filename)
        {
            Item itemToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            itemToSerialize = (Item)bFormatter.Deserialize(stream);
            stream.Close();
            return itemToSerialize;
        }
    }
}
