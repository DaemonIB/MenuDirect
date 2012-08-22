using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirect
{
    class MenuDirect
    {

        static List<Order> orders = new List<Order>();

        static Menu menu = new Menu();

        static void Main(string[] args)
        {
            CheckAdmin();
        }

        static void CheckAdmin()
        {
            Console.WriteLine("Press A if your an Admin. Press E if your an Employee");
            char ui = Console.ReadKey(true).KeyChar;

            if (ui == 'a')
            {
                Admin admin = new Admin(menu);
            }
            else if(ui == 'e')
            {
                MakeOrder();
            }
            CheckAdmin();
        }

        static void MakeOrder()
        {
            Console.WriteLine("Press Y to make an order.");
            char ui = Console.ReadKey(true).KeyChar;

            if (ui == 'y')
            {
                Order myOrder = new Order(menu);
                orders.Add(myOrder);
            }
        }
    }
}
