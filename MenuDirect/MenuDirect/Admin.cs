using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    class Admin
    {

        public String adminInput { get; set; }

        public Admin()
        {
            PrintAdminChoices();
            GetAdminChoice();
        }

        public void PrintAdminChoices()
        {
            Console.WriteLine("Hello Administrator!");
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1 - Add an item to the menu" + Environment.NewLine);
            Console.WriteLine("2 - Delete an item from the menu" + Environment.NewLine);
        }

        public void GetAdminChoice()
        {
            char adminChoice = Console.ReadKey(true).KeyChar;

            if (adminChoice == '1')
            {
                AddItemAdmin();
            }
            else if (adminChoice == '2')
            {
                DeleteItemFromMenu();
            }
        }

        public void AddItemAdmin()
        {
            Console.WriteLine("Please enter the name of your item to be added:");
            String newItemName = GetAdminInput();
            
            Console.WriteLine("Please enter the price of your item in this format: 5.23");
            double newItemPrice = Convert.ToDouble(Console.ReadLine());

            Item item = new Item(newItemName, newItemPrice);
            
            Menu menu = new Menu(item, true, false);

            Console.WriteLine(Environment.NewLine);
        }

        public String GetAdminInput()
        {
            adminInput = Console.ReadLine();

            return adminInput;
        }

        public void DeleteItemFromMenu()
        {
            Menu menu = new Menu(new Item("", 6), false, true);
        }
    }
}
