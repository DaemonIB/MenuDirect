using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    public class Admin
    {
        public String adminInput { get; set; }   //Used as the admins input string used later
        public char adminChoice { get; set; }  //Used for adding or deleting an item or confirming an order.
        public Menu menu { get; set; }  //Menu for the Admin to reference.

        public Admin(Menu menu)
        {
            this.menu = menu;  //The menu started from the beginning of the program is referenced.
            PrintAdminChoices();
            GetAdminChoice(adminChoice = Console.ReadKey(true).KeyChar);  //Gets a char thats pressed from the key and passed in to get the choice for the admin.
        }


        /**
         * 
         * Prints all the choices for the admin.
         * 
         */
        public void PrintAdminChoices()
        {
            Console.WriteLine(Environment.NewLine + "Hello Administrator!");
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1 - Add an item to the menu");
            Console.WriteLine("2 - Delete an item from the menu" + Environment.NewLine);
        }


        /**
         * Gets the char from user input to pick a choice.
         */
        public void GetAdminChoice(char adminChoice)
        {
            if (adminChoice == '1')
            {
                AddItemAdmin();
            }
            else if (adminChoice == '2')
            {
                DeleteItemFromMenu();
            }
        }


        /**
         * Takes in admin input for the item name to be added and then the price as well.
         * Also converts the input for the price to a double.
         */
        public void AddItemAdmin()
        {
            //Gets input for the item name.
            Console.WriteLine("Please enter the name of your item to be added:");
            String newItemName = GetAdminInput(adminInput = Console.ReadLine());
            
            //Gets input for the item price.
            Console.WriteLine("Please enter the price of your item in this format: 5.23");
            double newItemPrice = Convert.ToDouble(Console.ReadLine());

            Item item = new Item(newItemName, newItemPrice);  //Creates a new item.

            menu.AddToMenu(item);  //Adds the item to the menu.
            
            Console.WriteLine(Environment.NewLine);
        }

        /**
         * Takes in a string and returns the string.
         */
        public String GetAdminInput(string adminInput)
        {
            return adminInput;
        }
        

        /**
         * This is executed when the admin chooses the option to delete an item.
         * Deletes an item from the menu.
         */
        public void DeleteItemFromMenu()
        {
            menu.DeleteFromMenu();
        }
    }
}
