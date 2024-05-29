using Rise_of_Derma.entities;
using Rise_of_Derma.map;
using Rise_of_Derma.providers;
using System.Diagnostics;

namespace Rise_of_Derma.scenarios
{
    public class Level1
    {
        public (int, Player) InitLevel1(int elapsed, Player player)
        {
            // Print debug
            Debug.WriteLine("Running Level1");

            // Create and display matrix (LevelFile's content, ShowTime Setting, Elapsed Time)
            Matrix matrix = new Matrix(File.ReadAllLines("./scenarios/builds/Level1.txt", encoding: System.Text.Encoding.UTF8), true, elapsed, player);

            // Loop until level finished
            while (matrix.isFinished() == false)
            {
                // Display and handle movement
                matrix.Display();
                matrix.HandleKey();
            }

            // After the level ended return the time spent in the level
            return (matrix.getTimeSpent(), matrix.getPlayer());
        }
    }
}
