using Newtonsoft.Json.Linq;
using Rise_of_Derma.providers;
using System.Diagnostics;
using System.Text;

namespace Rise_of_Derma.scenarios
{
    public class TopList
    {
        public string? Data { get; private set; }

        // This called when TopList ran
        public void InitTopList()
        {
            // Print debug
            Debug.WriteLine("Running TopList");

            // Get the data from the game server
            GetTopListFromServer();

            // Wait until data is received
            Console.Clear();

            // Show loading 
            Loading();

            // If there is Data show it
            if (Data != null)
            {
                // Clear console before anything
                Console.Clear();

                // The data itself, than wait for enter
                Display();
                WaitKey.WaitForKey(ConsoleKey.Enter);

                // Clear and continue run
                Console.Clear();
            }
        }

        // This gets the data from the backend
        private async void GetTopListFromServer()
        {
            // Backend
            string url = "http://127.0.0.1:5000/get_top_list";

            // Create a new HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(url, null);

                    // Throttle to make it look like it loads something
                    Thread.Sleep(350);

                    // Ensure the response is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Output the response
                    Data = responseBody;
                }
                catch (HttpRequestException e)
                {
                    // Handle any errors
                    Debug.WriteLine($"Request error: {e.Message}");
                }
            }
        }

        // Simple Loading and error handling
        private void Loading() {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("     Betöltés.");

            int timer = 0;

            while (Data == null)
            {
                if (timer <= 8000)
                {
                    timer += 200;
                    Thread.Sleep(200);
                    Console.Write(".");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("     Valami hiba történt!\n\n     Folytatáshoz (Enter)");

                    WaitKey.WaitForKey(ConsoleKey.Enter);
                    break;
                }
            }
        }

        // Data display
        private void Display()
        {
            // Parse JSON
            JObject json = JObject.Parse(Data);

            // Access the top_list array
            JArray topList = (JArray)json["top_list"];

            // Display values
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Rise of Derma TOP Lista");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < topList.Count; i++)
            {
                Console.WriteLine($"     \t\t\t# {i+1}\t-\t{topList[i][1]}\t  -\t{topList[i][2]}");
            }
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
