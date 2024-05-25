using Rise_of_Derma.map;
using System.Diagnostics;

namespace Rise_of_Derma.scenarios
{
    public class MainMenu
    {
        public void InitMainMenu()
        {
            // Print debug
            Debug.WriteLine("Running MainMenu");

            // Create and display matrix
            Matrix matrix = new Matrix(File.ReadAllLines("./scenarios/builds/MainMenu.txt", encoding: System.Text.Encoding.UTF8));

            // Run MainMenu until Matrix is finished
            while (matrix.isFinished() == false)
            {
                // Display and handle movement
                matrix.Display();
                matrix.HandleKey();

                // If the response is 2 after a move it means that player is on the toplist button, so first reset the response than show toplist
                if (matrix.getResponse() == 2)
                {
                    matrix.setResponseDefault();

                    TopList topList = new TopList();
                    topList.InitTopList();

                }
                // If the response is 1 after a move it means that player is on the start button, so reset the response than preapare and start the game
                else if (matrix.getResponse() == 1) 
                {
                    matrix.setResponseDefault();

                    // Create a variable that stores the total time spent in game
                    int totalTimes = 0;

                    // Run level1
                    Level1 level1 = new Level1();
                    // InitLevel returns the time spent in the Level, add it to the total time
                    totalTimes = level1.InitLevel1(totalTimes);

                    // Run level2
                    Level1 level2 = new Level1();
                    // Here initLevel returns the time spent in the game because it sums the lasts
                    totalTimes = level2.InitLevel1(totalTimes);

                    // Game cycle ended show end screen
                    EndScreen endScreen = new EndScreen();
                    // Pass thru the stats
                    // TODO: Add other STATS
                    endScreen.initEndScreen(totalTimes);
                }
            }
        }
    }
}
