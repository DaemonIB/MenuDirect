using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    public class Admin
    {
        public String adminInput { get; set; }
        public char adminChoice { get; set; }
        public Menu menu { get; set; }

        public Admin(Menu menu)
        {
            this.menu = menu;
            PrintAdminChoices();
            GetAdminChoice(adminChoice = Console.ReadKey(true).KeyChar);
        }

        public void PrintAdminChoices()
        {
            Console.WriteLine(Environment.NewLine + "Hello Administrator!");
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1 - Add an item to the menu");
            Console.WriteLine("2 - Delete an item from the menu" + Environment.NewLine);
        }

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

        public void AddItemAdmin()
        {
            Console.WriteLine("Please enter the name of your item to be added:");
            String newItemName = GetAdminInput(adminInput = Console.ReadLine());
            
            Console.WriteLine("Please enter the price of your item in this format: 5.23");
            double newItemPrice = Convert.ToDouble(Console.ReadLine());

            Item item = new Item(newItemName, newItemPrice);

            menu.AddToMenu(item);
            
            Console.WriteLine(Environment.NewLine);
        }

        public String GetAdminInput(string adminInput)
        {
            return adminInput;
        }
        
        public void DeleteItemFromMenu()
        {
            menu.DeleteFromMenu();
        }
    }
}
