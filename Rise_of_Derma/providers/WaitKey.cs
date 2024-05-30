using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise_of_Derma.providers
{
    public class WaitKey
    {
        public static void WaitForKey(ConsoleKey key)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(100);
                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            } while (cki.Key != key);
        }
    }
}
