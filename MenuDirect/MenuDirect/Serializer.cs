﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace MenuDirect
{
    

    public class Serializer
    {
        public Serializer()
        {
        }

        public void SerializeObject(string filename, List<Item> itemToSerialize)
        {
            Process process = Process.Start("notepad.exe");
            // Wait one second.
            System.Threading.Thread.Sleep(1000);
            // End notepad.
            process.Kill();

            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, itemToSerialize);
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }

        public List<Item> DeSerializeObject(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                System.IO.FileStream f = System.IO.File.Create(filename);
                f.Close();
            }
            List<Item> itemToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            itemToSerialize = (List<Item>)bFormatter.Deserialize(stream);
            stream.Flush();
            stream.Close();
            stream.Dispose();
            return itemToSerialize;
        }
    }
}