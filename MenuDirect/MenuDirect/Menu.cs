using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;


namespace MenuDirect
{
    public class Menu
    {
        public List<Item> itemsOnMenu = new List<Item>();
        public Item _item { get; set; }

        public Menu()
        {
            
        }

        public void AddToMenu(Item item)
        {
            itemsOnMenu.Add(item);
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


        public void PrintMenu()
        {
            itemsOnMenu.Sort();
            int counter = 0;

            foreach (Item fromMenu in itemsOnMenu)
            {
                Console.WriteLine(counter + " - " + fromMenu.ToString());
                counter++;
            }
        }
    }
}
