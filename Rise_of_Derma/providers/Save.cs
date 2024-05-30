using Rise_of_Derma.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise_of_Derma.providers
{
    public class Save
    {
        private string ConfigPath { get; set; }
        private string SaveFilePath { get { return ConfigPath + "/savegame.txt"; } }

        public Save()
        {
            Config c = new Config();
            ConfigPath = c.getConfigPath();
        }

        public void createSaveFile(int levelDone, int totalTime, Player player) 
        {
            // Print debug
            Debug.WriteLine("Creating Save file");

            // Create file
            StreamWriter f = new StreamWriter(SaveFilePath, false, Encoding.UTF8);

            // Write the data into IT
            f.WriteLine($"levelDone={levelDone}");
            f.WriteLine($"totalTime={totalTime}");
            f.WriteLine($"killedEnemy={player.KilledEnemy}");
            f.WriteLine($"collectedCrystals={player.CrystcalCount}");
            f.Close();
        }

        public (int, int, Player, bool) returnSaveContentIfExists() 
        {
            // Set default values
            int levelDone = 0;
            int totalTime = 0;
            Player player = new Player();
            bool exists = false;

            // If file exists than load the data from it
            if (File.Exists(SaveFilePath))
            {
                // Read File
                string[] file = File.ReadAllLines(SaveFilePath);
                exists = true;

                // Parse Data
                foreach (var item in file)
                {
                    string[] sor = item.Split("=");
                    switch (sor[0])
                    {
                        case "levelDone":
                            levelDone = int.Parse(sor[1]);
                            break;
                        case "totalTime":
                            totalTime = int.Parse(sor[1]);
                            break;
                        case "killedEnemy":
                            player.KilledEnemy = int.Parse(sor[1]);
                            break;
                        case "collectedCrystals":
                            player.CrystcalCount = int.Parse(sor[1]);
                            break;
                    }
                }

                // Return the data
                return (levelDone, totalTime, player, exists);
            }
            else
            {
                // Return empty data
                return (levelDone, totalTime, player, exists);
            }
        }

        public void deleteSave()
        {
            if (File.Exists(SaveFilePath))
            {
                File.Delete(SaveFilePath);
            }
        }
    }
}
