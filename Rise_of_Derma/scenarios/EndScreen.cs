using Newtonsoft.Json.Linq;
using Rise_of_Derma.providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rise_of_Derma.scenarios
{
    public class EndScreen
    {
        public void initEndScreen(int totalSpentTime) 
        {
            // Show the endScreen than wait for key
            Display(totalSpentTime);
            WaitKey.WaitForKey(ConsoleKey.Enter);

            // TODO: OTHER STATS, SYNC RESULTS
        }

        private void Display(int seconds)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Gratuláunk! Sikeresen teljesítetted a játékot!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Statisztikáid:");
            Console.WriteLine($"       Játékban töltött időd: {TimeFormats.FormatSeconds(seconds)}");
            Console.WriteLine($"       Megölt ellenfelek: X");
            Console.WriteLine($"       Összegyűjtött kristályok: X");
            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine();
            Console.WriteLine("     Eredményeidet szinkronizáltuk!");
            Console.WriteLine("     Ha úgy véljük, hogy eredményed eléri a szintet a Top Listára való");
            Console.WriteLine("     felkerüléshez, felkerülsz oda!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Vissza (Enter)");
        }
    }
}
