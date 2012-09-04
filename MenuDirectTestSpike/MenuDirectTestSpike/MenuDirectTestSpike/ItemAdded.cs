using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirectTestSpike
{
    public class ItemAdded
    {
        public delegate void EnterItem(String input);

        public event EnterItem inputToDB;

        public void CallEvent(String input)
        {
            inputToDB.Invoke(input);

            Console.WriteLine("IN CALL EVENT" + input);
        }
    }
}
