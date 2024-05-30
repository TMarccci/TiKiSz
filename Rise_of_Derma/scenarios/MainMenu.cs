using Rise_of_Derma.entities;
using Rise_of_Derma.map;
using Rise_of_Derma.providers;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            // Init Save System
            Save save = new Save();

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

                    // Try to load savegame
                    (int, int, Player, bool) saveGame = save.returnSaveContentIfExists();

                    // Savegame not exists create new game
                    if (saveGame.Item4 == false)
                    {
                        // Create a variable that stores the total time spent in game
                        (int, Player, bool) data = (0, new Player(), false);
                        Level1 level1 = new Level1();
                        Level2 level2 = new Level2();
                        Level3 level3 = new Level3();
                        Level4 level4 = new Level4();

                        // Run level1
                        data = level1.InitLevel1(data.Item1, data.Item2, data.Item3);
                        // If level Done save progress
                        save.createSaveFile(1, data.Item1, data.Item2);

                        // Run from level2
                        data = level2.InitLevel2(data.Item1, data.Item2, data.Item3);
                        // If level Done save progress
                        save.createSaveFile(1, data.Item1, data.Item2);

                        // Run level 3
                        data = level3.InitLevel3(data.Item1, data.Item2, data.Item3);
                        // If level Done save progress
                        save.createSaveFile(1, data.Item1, data.Item2);

                        // Run level 4
                        data = level4.InitLevel4(data.Item1, data.Item2, data.Item3);

                        save.deleteSave();

                        // If no game over show endscreen
                        if (data.Item3 == false)
                        {
                            // Game cycle ended show end screen
                            EndScreen endScreen = new EndScreen();
                            endScreen.initEndScreen(data);
                        }
                        else
                        {
                            // Show Game Over Screen
                            GameOver gameOver = new GameOver();
                            gameOver.initGameOverScreen(data);
                        }
                    }
                    // Savegame exists continue from where it should be
                    else
                    {
                        // Create a variable that stores the total time spent in game
                        (int, Player, bool) data = (saveGame.Item2, saveGame.Item3, false);
                        Level2 level2 = new Level2();
                        Level3 level3 = new Level3();
                        Level4 level4 = new Level4();

                        switch (saveGame.Item1)
                        {
                            // Level 1 Complete
                            case 1:
                                // Run from level2
                                data = level2.InitLevel2(data.Item1, data.Item2, data.Item3);

                                // If level Done save progress
                                save.createSaveFile(1, data.Item1, data.Item2);

                                // Run level 3
                                data = level3.InitLevel3(data.Item1, data.Item2, data.Item3);

                                // If level Done save progress
                                save.createSaveFile(1, data.Item1, data.Item2);

                                // Run level 4
                                data = level4.InitLevel4(data.Item1, data.Item2, data.Item3);

                                break;
                            // Level 2 Complete
                            case 2:
                                // Run from level3
                                data = level3.InitLevel3(data.Item1, data.Item2, data.Item3);

                                // If level Done save progress
                                save.createSaveFile(1, data.Item1, data.Item2);

                                // Run level 4
                                data = level4.InitLevel4(data.Item1, data.Item2, data.Item3);

                                break;
                            // Level 3 Complete
                            case 3:
                                // Run level 4
                                data = level4.InitLevel4(data.Item1, data.Item2, data.Item3);

                                break;
                        }

                        save.deleteSave();

                        // If no game over show endscreen
                        if (data.Item3 == false)
                        {
                            // Game cycle ended show end screen
                            EndScreen endScreen = new EndScreen();
                            endScreen.initEndScreen(data);
                        }
                        else
                        {
                            // Show Game Over Screen
                            GameOver gameOver = new GameOver();
                            gameOver.initGameOverScreen(data);
                        }
                    }
                }

                // Name change
                else if (matrix.getResponse() == 105)
                {
                    matrix.setResponseDefault();

                    Config config = new Config();
                    config.setConfig("UserName", "");

                    Name name = new Name();
                    name.Set();
                }

                // Exit
                else if (matrix.getResponse() == 100)
                {
                    return;
                }
            }
        }
    }
}
