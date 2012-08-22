using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    class Order
    {
        public int orderNumber { get; set; } //Order has an order number
        public double orderTotal { get; set; }  //Order has how much the order cost.
        public int convertedUserInput { get; set; } 
        List<Item> order = new List<Item>();  //An order has alist containing items.
        public Menu menu { get; set; }

        public Order(Menu menu)
        {
            this.menu = menu;  //References the menu being used throughtout the program.
            GetOrderNumber();  //Needs an order number and asks for it.
            GetOrderOptions(); //Gives and gets the order options.
        }


        /**
         * Gets an order number from the user.
         */
        public void GetOrderNumber()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Please enter the order number.");
            orderNumber = ConvertUI(GetUserInput());
        }


        /**
         * Gets the orders options to add, delete, or confirm an order.
         */
        public void GetOrderOptions()
        {
            Console.WriteLine("Press A to add an item. Press D to delete an item. Press C to confirm this order.");
            char ui = Console.ReadKey(true).KeyChar; //Reads the key pressed and stored as a char to be compared.
            
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
                Console.Clear();  //Clears the console.
                Console.WriteLine("You've entered an invalid response, please try again.");
            }
        }


        /**
         * Gets the users input.
         */
        public String GetUserInput()
        {
            String userInput = Console.ReadLine();

            return userInput;
        }


        /**
         * Converts user input to an int for the order number.
         */
        public int ConvertUI(String userInput)
        {
            try
            {
                convertedUserInput = Convert.ToInt16(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine("You entered an invalid order number.");
                Order ordered = new Order(menu);  //Starts a new order if a number wasn't entered correctly.
            }

            return convertedUserInput;
        }


        /**
         * Gets all the item reference number from the menu.
         */
        public void GetItemNumbers()
        {
            int counter = 0; //Starts the reference numbers from 0.

            //Prints out each item with a reference number
            foreach (Item item in menu.itemsOnMenu)
            {
                Console.WriteLine(counter + " - " + item);
                counter++; //Adds to the reference number.
            }
        }


        /**
         * 
         */
        public void AddItemOrder()
        {
            GetItemNumbers();  //Gets the items.

            Console.WriteLine(Environment.NewLine + "Enter the number for the item to be added:");

            int itemNumber = ConvertUI(GetUserInput());

            order.Add(menu.itemsOnMenu[itemNumber]);  //Adds the item to the order from the item on the menu (Or in the menu list).

            FinalizeOrder();
        }


        /**
         * Deletes an item from the order.
         */
        public void DeleteitemOrder()
        {
            GetItemNumbers();

            Console.WriteLine(Environment.NewLine + "Enter the number for the item to be deleted:");

            int itemNumber = ConvertUI(GetUserInput());

            order.Remove(menu.itemsOnMenu[itemNumber]); //Removes the item from the order.

            FinalizeOrder();
        }


        /**
         * Shows what's on the order so far.
         */
        public void PrintOrder()
        {
            //Prints each item on the order.
            foreach (Item ordered in order)
            {
                Console.WriteLine(ordered);
            }
        }


        /**
         * Gives details on the order to see if the employee wants to add, delete, or confirm the order.
         */
        public void FinalizeOrder()
        {
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "Your order so far:");

            PrintOrder();  //Shows the order

            GetOrderOptions();  //Asks the order options one last time.
        }


        /**
         * The price is calculated and the order is printed with the order information.
         */
        public void ConfirmOrder()
        {
            Console.WriteLine(Environment.NewLine);

            Console.Clear();
            Console.WriteLine("Your finalized order for order number " + orderNumber);
            PrintOrder();
            CalculateTotal();

            Console.WriteLine(Environment.NewLine + Environment.NewLine);

        }


        /**
         * Calculates the order total by going through each item in the order and adding each price.
         */
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
