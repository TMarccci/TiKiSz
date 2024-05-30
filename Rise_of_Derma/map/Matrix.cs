
using Rise_of_Derma.entities;
using Rise_of_Derma.providers;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace Rise_of_Derma.map
{
    public class Matrix
    {
        // Properties and variables
        private char[,] Area { get; }
        private int W = 80;
        private int H = 20;
        private System.Timers.Timer timer;
        List<string> enemyNumbers = new();

        private (int x, int y) PlayerPos { get; set; }
        private bool IsFinished { get; set;  }
        private int Response { get; set; }
        private int TimeSpent { get; set; }
        private bool DisplayInformations { get; set; }
        private Player Playr { get; set; }
        public int AtLevel { get; set; }

        // Constructors, first used by main menu, seconds by levels
        public Matrix(IEnumerable<string> l)
        {
            // Create and set variables
            Area = new char[W, H];
            IsFinished = false;
            Response = 0;
            TimeSpent = 0;
            DisplayInformations = false;
            Playr = new();
            AtLevel = 0;

            // Fill the enemyNumbers list
            for (int i = 1; i < 10; i++)
            {
                enemyNumbers.Add(i.ToString());
            }

            // Run initalization
            FillWithSpace();
            StartTimer();
            ParseMap(l);
        }

        public Matrix(IEnumerable<string> l, bool displayInformations, int elapsed, Player playR, int level)
        {
            // Create and set variables
            Area = new char[W, H];
            IsFinished = false;
            Response = 0;
            TimeSpent = 0 + elapsed;
            DisplayInformations = displayInformations;
            Playr = playR;
            Playr.Power = 1;
            AtLevel = level;

            // Fill the enemyNumbers list
            for (int i = 1; i < 10; i++)
            {
                enemyNumbers.Add(i.ToString());
            }

            // Run initalization
            FillWithSpace();
            StartTimer();
            ParseMap(l);
        }

        // Parse map function, this puts the objects into the matrix
        private void ParseMap(IEnumerable<string> l)
        {
            // Go thru each line of the map

            foreach (string s in l)
            {
                // Split than parse variables
                string[] n = s.Split(';');

                int x = int.Parse(n[0]);
                int y = int.Parse(n[1]);
                string type = n[2];

                // Supported types:
                // 50;15;PLAYERSPAWN
                //  4; 2;TEXT       ;RISE OF DERMA
                // 15; 9;BUTTON     ;10; 3;START!;#
                // 20; 5;WALL
                // 60; 9;FINISHLEVEL
                // 50; 3;CRYSTAL

                switch (type)
                {
                    // Handle the spawn of the player
                    case "PLAYERSPAWN":
                        SetCharTo(x, y, 'x');
                        PlayerPos = (x, y);
                        break;

                    // Put text on matrix
                    case "TEXT":
                        string text = n[3];
                        int textLen = text.Length;

                        for (int i = 0; i < textLen; i++)
                        {
                            SetCharTo(x + i, y, text[i]);
                        }
                        break;

                    // Button like object on map, every button border must handled
                    case "BUTTON":
                        int w = int.Parse(n[3]) + 2;
                        int h = int.Parse(n[4]);
                        string buttonText = n[5];
                        int buttonTextLen = buttonText.Length;
                        char buttonRoundChar = char.Parse(n[6]);

                        for (int i = 0; i < w; i++)
                        {
                            for (int j = 0; j < h; j++)
                            {
                                if (j != 1 || i == 0 || j != 1 || i == w - 1)
                                {
                                    SetCharTo(x + i, y + j, buttonRoundChar);
                                }
                            }
                        }

                        for (int i = 0; i < buttonTextLen; i++)
                        {
                            SetCharTo(x + i + (w / 2) - (buttonTextLen / 2), y + 1, buttonText[i]);
                        }
                        break;

                    // Wall object
                    case "WALL":
                        SetCharTo(x, y, '@');
                        break;

                    // Finish level point
                    case "FINISHLEVEL":
                        SetCharTo(x, y, 'C');
                        break;

                    // Crystal
                    case "CRYSTAL":
                        SetCharTo(x, y, '*');
                        break;

                    // Enemy
                    case "ENEMY":
                        SetCharTo(x, y, char.Parse(n[3]));
                        break;
                }
            }
        }

        // This starts a timer with the level
        private async void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TickTime;
            timer.Enabled = true;
        }

        // This runs every seconds (if DisplayTimer true than updates on the screen)
        private void TickTime(Object source, System.Timers.ElapsedEventArgs e) { 
            // Bump time spent
            TimeSpent += 1;

            // If display enabled update on screen
            if (DisplayInformations)
            {
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top-2);
                Console.WriteLine($"{AtLevel}/4. Szint | Eltelt idő: {TimeFormats.FormatSeconds(getTimeSpent())}");
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
            }
        }

        // This fills the matrix with empty spaces
        private void FillWithSpace()
        {
            // Fill the area with empty spaces
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Area[i, j] = ' ';
                }
            }
        }

        // This displays the matrix's content with walls and stats, etc
        public void Display()
        {
            // Print the top border
            FastConsole.WriteLine(new string('_', W + 2));

            // Print the content rows
            for (int mag = 0; mag < H; mag++)
            {
                FastConsole.Write("|");
                for (int szel = 0; szel < W; szel++)
                {
                    FastConsole.Write(Area[szel, mag].ToString());
                }
                FastConsole.WriteLine("|");
            }

            // Print the bottom border
            FastConsole.WriteLine(new string('‾', W + 2));

            // Flush the buffer
            FastConsole.Flush();

            // Statistic Bars
            // Time Spent Part, etc, if DisplayInformations enabled than it shows else empty line
            if (DisplayInformations)
            {
                Console.WriteLine($"{AtLevel}/4. Szint | Eltelt idő: {TimeFormats.FormatSeconds(getTimeSpent())}");
                Console.WriteLine($"Erő: {Playr.Power} | " +
                    $"Összegyűjtött kristályok: {Playr.CrystcalCount} db | " +
                    $"Megölt ellenfelek: {Playr.KilledEnemy} db");
            }
            else 
            { 
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        // Updates to a specific char in the matrix (LEFT, TOP, CHAR)
        public void SetCharTo(int x, int y, char c)
        {
            Area[x, y] = c;
        }

        // Returns the IsFinished property
        public bool isFinished()
        {
            return IsFinished;
        }

        // Returns the Response property
        public int getResponse()
        {
            return Response;
        }

        // Returns the TimeSpent property
        public int getTimeSpent() {
            return TimeSpent; 
        }

        // Returns the PlayR property
        public Player getPlayer() { 
            return Playr; 
        }

        // This sets the level's response to default
        public void setResponseDefault()
        { Response = 0; }

        // Is there enemy left and crystal left?
        private bool checkEnemyAndCrystalLeft()
        {
            List<string> banCharList = new();
            foreach (var item in enemyNumbers)
            {
                banCharList.Add(item);
            }
            banCharList.Add("*");

            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    string k = Area[i, j].ToString();

                    if (k != " ") ; 
                    {
                        if (banCharList.Contains(k))
                        {
                            return true;
                        }                        
                    }
                }
            }

            return false;
        }

        public void movePlayer(int x, int y)
        {
            // If inside the matrix than...
            if ((x > -1 && x < W) && (y > -1 && y < H))
            {
                char c = Area[x, y];

                // Top List Button Character
                if (c == '%')
                {
                    Response = 2;
                }
                // Start Button Character
                else if (c == '#')
                {
                    Response = 1;
                }
                // Exit Button Character
                else if (c == 'Q')
                {
                    Response = 100;
                }
                // Wall
                else if (c == '@')
                {
                    return;
                }
                // Crystal
                else if (c == '*') 
                {
                    // Move player to the crystals place
                    SetCharTo(PlayerPos.x, PlayerPos.y, ' ');
                    SetCharTo(x, y, 'x');
                    PlayerPos = (x, y);

                    // Bump crystalcount
                    Playr.CrystcalCount++;
                }
                // Finish Level Character
                else if (c == 'C')
                {
                    if (checkEnemyAndCrystalLeft() == false)
                    {
                        IsFinished = true;
                        timer.Enabled = false;                        
                    }
                }
                // Enemy characters
                else if (enemyNumbers.Contains(c.ToString())) 
                {
                    // If the player's power is bigger or equal to enemy power kill it
                    if (Playr.Power >= int.Parse(c.ToString()))
                    {
                        // Remove and move player to it's position
                        SetCharTo(PlayerPos.x, PlayerPos.y, ' ');
                        SetCharTo(x, y, 'x');
                        PlayerPos = (x, y);

                        // Bump killed enemy count
                        Playr.KilledEnemy++;

                        // Bump power to killed enemy power +1 if killed a same power enemy
                        if (int.Parse(c.ToString()) == Playr.Power)
                        {
                            Playr.Power++;
                        }
                    }
                    // Less power, game over
                    else
                    {
                        Response = 10;
                        IsFinished = true;
                        timer.Enabled = false;
                    }
                }
                // If not any special case than move player to the wanted position
                else
                {
                    SetCharTo(PlayerPos.x, PlayerPos.y, ' ');
                    SetCharTo(x, y, 'x');
                    PlayerPos = (x, y);
                }
            }
        }

        // This function handles the movement inside the matrix
        public void HandleKey()
        {
            // Get key
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey(true);

            // Parse basic movement than call in movePlayer to check if possible
            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    movePlayer(PlayerPos.x - 1, PlayerPos.y);
                    break;
                case ConsoleKey.RightArrow:
                    movePlayer(PlayerPos.x + 1, PlayerPos.y);
                    break;
                case ConsoleKey.DownArrow:
                    movePlayer(PlayerPos.x, PlayerPos.y + 1);
                    break;
                case ConsoleKey.UpArrow:
                    movePlayer(PlayerPos.x, PlayerPos.y - 1);
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}
