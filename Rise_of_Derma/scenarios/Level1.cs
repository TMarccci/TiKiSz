using Rise_of_Derma.entities;
using Rise_of_Derma.map;
using Rise_of_Derma.providers;
using System.Diagnostics;

namespace Rise_of_Derma.scenarios
{
    public class Level1
    {
        public (int, Player, bool) InitLevel1(int elapsed, Player player, bool gameOver)
        {
            if (gameOver == false) 
            {
                // Print debug
                Debug.WriteLine("Running Level1");

                // Create and display matrix (LevelFile's content, ShowTime Setting, Elapsed Time)
                Matrix matrix = new Matrix(File.ReadAllLines("./scenarios/builds/Level1.txt", encoding: System.Text.Encoding.UTF8), true, elapsed, player, 1);

                // Loop until level finished
                while (matrix.isFinished() == false)
                {
                    // Display and handle movement
                    matrix.Display();
                    matrix.HandleKey();
                }

                if (matrix.getResponse() == 10)
                {
                    // After the level ended return the time spent in the level
                    return (matrix.getTimeSpent(), matrix.getPlayer(), true);
                }
                else
                {
                    // Level Finished Successfully send data
                    return (matrix.getTimeSpent(), matrix.getPlayer(), false);
                }
            }

            return (elapsed, player, true);
        }
    }
}
