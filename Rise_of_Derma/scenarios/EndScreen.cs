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
    public class EndScreen
    {
        public void initEndScreen((int, Player, bool) data) 
        {
            // Show the endScreen than wait for key
            Display(data.Item1, data.Item2);
            SyncDataWithServer(data.Item1);
            WaitKey.WaitForKey(ConsoleKey.Enter);
        }

        private void Display(int seconds, Player player)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Gratuláunk! Sikeresen teljesítetted a játékot!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Statisztikáid:");
            Console.WriteLine($"       Játékban töltött időd: {TimeFormats.FormatSeconds(seconds)}               ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.WriteLine($"       Megölt ellenfelek: {player.KilledEnemy} db                    ⠀⠀⠀⠀⣠⡶⠀⣸⣇⠀⢶⣄⠀⠀⠀⠀⠀⠀");
            Console.WriteLine($"       Összegyűjtött kristályok: {player.CrystcalCount} db       ⠀     ⠀⠀⢀⣠⣾⣿⠃⢠⣿⣿⡄⠘⣿⣷⣄⡀⠀⠀⠀");
            Console.WriteLine($"                                                  ⠀⢀⣴⣿⣿⣿⡿⠀⣼⣿⣿⣧⠀⢿⣿⣿⣿⣦⡀⠀");
            Console.WriteLine($"                                                  ⠠⣈⠙⠻⢿⣿⠃⢰⣿⣿⣿⣿⡆⠘⣿⡿⠟⠋⣁⠄"); 
            Console.WriteLine($"                                             ⠀     ⣿⣿⣶⣤⡀⠀⠉⠉⠉⠉⠉⠉⠀⢀⣤⣶⣿⣿⠀");
            Console.WriteLine($"    Eredményeidet szinkronizáltuk!                ⠀⢹⣿⣿⣿⣧⠀⣿⣿⣿⣿⣿⣿⠀⣼⣿⣿⣿⡏⠀");
            Console.WriteLine($"       Ha úgy véljük, hogy eredményed             ⠀⢸⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⡇⠀");
            Console.WriteLine($"       eléri a szintet a Top Listára való         ⠀⠈⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⠁⠀");
            Console.WriteLine($"       felkerüléshez, felkerülsz oda!             ⠀⠀⢻⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⡟⠀⠀");
            Console.WriteLine($"                                                  ⠀⠀⢸⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⡇⠀⠀");
            Console.WriteLine($"                                                  ⠀⠀⠘⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⠃⠀⠀");
            Console.WriteLine($"                                                  ⠀⠀⠀⢻⣿⣿⠀⢹⣿⣿⣿⣿⡏⠀⣿⣿⡟⠀⠀⠀");
            Console.WriteLine($"                                                  ⠀⠀⠀⠀⠙⢿⠀⢸⣿⣿⣿⣿⡇⠀⡿⠋⠀⠀⠀⠀");
            Console.WriteLine($"                                             ⠀⠀⠀⠀⠀     ⠀⠀⠈⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"     Vissza (Enter)");

        }

        private async void SyncDataWithServer(int seconds)
        {
            // Backend
            string url = "https://rod.tmarccci.hu/send_result";

            // Create a new HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Get username
                    Config config = new Config();

                    // 
                    var obj = new
                    {
                        name = config.UserName,
                        time = $"{seconds}",
                    };

                    // Convert it to JSON
                    JsonContent content = JsonContent.Create(obj);

                    Debug.WriteLine(content);

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Ensure the response is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    // Handle any errors
                    Debug.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }
}
