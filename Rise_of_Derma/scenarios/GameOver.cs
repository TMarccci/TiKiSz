using Newtonsoft.Json.Linq;
using Rise_of_Derma.entities;
using Rise_of_Derma.providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rise_of_Derma.scenarios
{
    public class GameOver
    {
        public void initGameOverScreen((int, Player, bool) data) 
        {
            // Show the gameOver than wait for key
            Display(data.Item1, data.Item2);
            WaitKey.WaitForKey(ConsoleKey.Enter);
        }

        private void Display(int seconds, Player player)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Meghaltál! Sajnáltatos módon elveszítetted a játékot!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Statisztikáid:");
            Console.WriteLine($"       Játékban töltött időd: {TimeFormats.FormatSeconds(seconds)}");
            Console.WriteLine($"       Megölt ellenfelek: {player.KilledEnemy} db");
            Console.WriteLine($"       Összegyűjtött kristályok: {player.CrystcalCount} db");
            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
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
