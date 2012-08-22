using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MenuDirect
{
    public class Menu
    {
        public List<Item> itemsOnMenu = new List<Item>();  //A list of items that are on the menu.
        public Item _item { get; set; }


        /**
         * Adds an item to the menu.
         */
        public void AddToMenu(Item item)
        {
            itemsOnMenu.Add(item);
        }

        /**
         * Prints the items on the menu to reference which item can be deleted.
         * Gives input for which item to delete.
         */
        public void DeleteFromMenu()
        {
            PrintMenu();

            Console.WriteLine("Which item would you like to delete?");

            itemsOnMenu.RemoveAt(GetUserInput());  //Removes the item specified by the user.
        }


        //Gets the item number to delete and converts the string to an int.
        public int GetUserInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }


        /**
         * Prints all items on the menu.
         */
        public void PrintMenu()
        {
            itemsOnMenu.Sort(); //Sorts the array of item in the order so choices stay the same and cannot be jumbled.

            int counter = 0; //This counter is used to get the item choice to reference the item in the menuList.

            //Loops through the menu list and prints each item with the reference number.
            foreach (Item fromMenu in itemsOnMenu)
            {
                Console.WriteLine(counter + " - " + fromMenu.ToString());  //Prints an item
                counter++; //Add the to the reference number.
            }
        }
    }
}
