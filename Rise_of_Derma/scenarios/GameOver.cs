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
            Console.WriteLine("     Meghaltál! Sajnáltatos módon elveszítetted a játékot!");
            Console.WriteLine();
            Console.WriteLine("     Statisztikáid:");
            Console.WriteLine($"       Játékban töltött időd: {TimeFormats.FormatSeconds(seconds)}");
            Console.WriteLine($"       Megölt ellenfelek: {player.KilledEnemy} db");
            Console.WriteLine($"       Összegyűjtött kristályok: {player.CrystcalCount} db");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t88888888888888888888888888888888888888888888888888" +
                              "\n\t\t88888888888888888888P\"\"  \"\"98888888888888888888888" +
                              "\n\t\t88888888888P\"88888P          988888\"98888888888888" +
                              "\n\t\t88888888888  \"9888            888P\"  8888888888888" +
                              "\n\t\t8888888888888bo \"9  d8o  o8b  P\" od888888888888888" +
                              "\n\t\t8888888888888888bob 98\"  \"8P dod888888888888888888" +
                              "\n\t\t8888888888888888888    db    888888888888888888888" +
                              "\n\t\t888888888888888888888      88888888888888888888888" +
                              "\n\t\t888888888888888888P\"9bo  odP\"988888888888888888888" +
                              "\n\t\t888888888888888P\" od88888888bo \"988888888888888888" +
                              "\n\t\t8888888888888   d88888888888888b   888888888888888" +
                              "\n\t\t88888888888888oo8888888888888888oo8888888888888888"); 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Vissza (Enter)");
        }
    }
}
