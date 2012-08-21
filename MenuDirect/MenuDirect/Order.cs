using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    class Order
    {
        public int orderNumber { get; set; }
        public double orderTotal { get; set; }
        public int convertedUserInput { get; set; }
        List<Item> order = new List<Item>();
        Menu menu = new Menu(false, false);

        public Order()
        {
            GetOrderNumber();
            GetOrderOptions();
        }

        public void GetOrderNumber()
        {
            Console.WriteLine("Getting Order Number." + Environment.NewLine);
            Console.WriteLine("Please enter the order number.");
            orderNumber = ConvertUI(GetUserInput());
        }

        public void GetOrderOptions()
        {
            Console.WriteLine("Press A to add an item. Press D to delete an item. Press C to confirm this order.");
            char ui = Console.ReadKey(true).KeyChar;
            
            if (ui == 'a')
            {
                AddItemOrder();
            }
            else if (ui == 'd')
            {
                DeleteitemOrder();
            }
            else if (ui == 'c')
            {
                ConfirmOrder();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You've entered an invalid response, please try again.");
            }
        }

        public String GetUserInput()
        {
            String userInput = Console.ReadLine();

            return userInput;
        }

        public int ConvertUI(String userInput)
        {
            try
            {
                convertedUserInput = Convert.ToInt16(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine("You entered an invalid order number.");
                Order ordered = new Order();
            }

            return convertedUserInput;
        }

        public void GetItemNumbers()
        {
            int counter = 0;
            foreach (Item item in menu.itemsOnMenu)
            {
                Console.WriteLine(counter + " - " + item);
                counter++;
            }
        }

        public void AddItemOrder()
        {
            GetItemNumbers();

            Console.WriteLine(Environment.NewLine + "Enter the number for the item to be added:");

            int itemNumber = ConvertUI(GetUserInput());

            order.Add(menu.itemsOnMenu[itemNumber]);

            FinalizeOrder();
        }

        public void DeleteitemOrder()
        {
            GetItemNumbers();

            Console.WriteLine(Environment.NewLine + "Enter the number for the item to be deleted:");

            int itemNumber = ConvertUI(GetUserInput());

            order.Remove(menu.itemsOnMenu[itemNumber]);

            FinalizeOrder();
        }

        public void PrintOrder()
        {
            foreach (Item ordered in order)
            {
                Console.WriteLine(ordered);
            }
        }

        public void FinalizeOrder()
        {
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "Your order so far:");

            PrintOrder();

            GetOrderOptions();
        }

        public void ConfirmOrder()
        {
            Console.WriteLine(Environment.NewLine);

            Console.Clear();
            Console.WriteLine("Your finalized order for order number " + orderNumber);
            PrintOrder();
            CalculateTotal();

            Console.WriteLine(Environment.NewLine + Environment.NewLine);

        }

        public void CalculateTotal()
        {
            foreach (Item price in order)
            {
                orderTotal += price._itemPrice;
            }
            Console.WriteLine("Total: $" + orderTotal);
        }
    }
}
