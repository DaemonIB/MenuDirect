using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace MenuDirect
{
    class Menu
    {
        public List<Item> itemsOnMenu = new List<Item>();
        public String menuFileLocation { get; set; }
        public bool _isAdding { get; set; }
        public bool _isDeleting { get; set; }
        public Item _item { get; set; }

        public Menu(Item item, bool isAdding, bool isDeleting)
        {
            menuFileLocation = "C://TEMP/MenuDirect.txt";
            LoadMenu();
            _isAdding = isAdding;
            _item = item;
            _isDeleting = isDeleting;
            CheckAddOrDelete();
            PrintMenu();
            SaveMenu();
        }

        public Menu(bool isAdding, bool isDeleting)
        {
            _isAdding = isAdding;
            _isDeleting = isDeleting;
            menuFileLocation = "C://TEMP/MenuDirect.txt";
            LoadMenu();
        }

        public void LoadMenu()
        {
            if (System.IO.File.Exists(menuFileLocation))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(menuFileLocation);

                var file = System.IO.File.ReadLines(menuFileLocation);

                foreach (String line in file)
                {
                    
                    itemsOnMenu.Add(line);
                }

                sr.Dispose();
                sr.Close();
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Could not find file. Making new Menu.");
                SaveMenu();
            }
        }

        public void CheckAddOrDelete()
        {
            if (_isAdding & !_isDeleting)
            {
                AddToMenu();
            }
            else
            {
                DeleteFromMenu();
            }
        }

        public void CheckIfBeingReferenced()
        {
            if (!_isAdding & !_isDeleting)
            {
                PrintMenu();
            }
        }

        public void AddToMenu()
        {
            itemsOnMenu.Add(_item);
        }

        public void DeleteFromMenu()
        {
            PrintMenu();

            Console.WriteLine("Which item would you like to delete?");

            itemsOnMenu.RemoveAt(GetUserInput());
        }

        public int GetUserInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }

        public void SaveMenu()
        {
            System.IO.TextWriter tw = new System.IO.StreamWriter(menuFileLocation);

            foreach (Item items in itemsOnMenu)
            {
                tw.WriteLine(items);
            }

            tw.Flush();
            tw.Close();
        }

        public void PrintMenu()
        {
            itemsOnMenu.Sort();
            int counter = 0;

            foreach (Item fromMenu in itemsOnMenu)
            {
                Console.WriteLine(counter + " - " + fromMenu);
                counter++;
            }
        }
    }
}
