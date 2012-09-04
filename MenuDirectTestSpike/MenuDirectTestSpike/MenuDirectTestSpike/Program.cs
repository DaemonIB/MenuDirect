using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirectTestSpike
{
    public class Program
    {
        private static Random _rng = new Random();
        private static string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static List<Chef> chefsList = new List<Chef>();

        public static void Main(String[] args)
        {
            DatabaseInserter theInserter = new DatabaseInserter();

            theInserter.EnterItemToDB(RandomString(5));
        }

        private static string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
