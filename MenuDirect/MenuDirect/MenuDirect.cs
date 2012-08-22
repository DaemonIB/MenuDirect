using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    class MenuDirect
    {

        static List<Order> orders = new List<Order>();  //Puts all orders into a list.

        static Menu menu = new Menu();  //A new menu is made at the beginning of the applciation.

        static void Main(string[] args)
        {
            CheckAdmin(); //Starts off by checking if an employee or admin is using the program.
        }


        /**
         * Check if the user is an admin or an employee.
         */
        static void CheckAdmin()
        {
            Console.WriteLine("Press A if your an Admin. Press E if your an Employee");
            char ui = Console.ReadKey(true).KeyChar; //Reads the keypress as a char.

            if (ui == 'a')
            {
                Admin admin = new Admin(menu);
            }
            else if(ui == 'e')
            {
                MakeOrder();
            }

            CheckAdmin();  //After the admin goes through or an employee goes through, the program checks who is on the system.
        }

        static void MakeOrder()
        {
            Console.WriteLine("Press Y to make an order.");
            char ui = Console.ReadKey(true).KeyChar;  //Reads the keypress and kept as a char.

            if (ui == 'y')
            {
                Order myOrder = new Order(menu);  //Creates a new order and passes the menu to reference items.
                orders.Add(myOrder);  //Adds the confirmed order to the orderslist.
            }
            CheckAdmin();
        }
    }
}
