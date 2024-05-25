
using Rise_of_Derma.providers;
using System.Numerics;
using System.Threading;
using System.Timers;

namespace Rise_of_Derma.map
{
    public class Matrix
    {
        private char[,] Area { get; }
        private int W = 80;
        private int H = 20;
        private System.Timers.Timer timer;

        public (int x, int y) PlayerPos { get; private set; }
        private bool IsFinished { get; set;  }
        private int Response { get; set; }
        private int TimeSpent { get; set; }
        private bool DisplayTimer { get; set; }

        public Matrix(IEnumerable<string> l)
        {
            Area = new char[W, H];
            IsFinished = false;
            Response = 0;
            TimeSpent = 0;
            DisplayTimer = false;
            FillWithSpace();
            StartTimer();
            ParseMap(l);
        }

        public Matrix(IEnumerable<string> l, bool displayTimer, int elapsed)
        {
            Area = new char[W, H];
            IsFinished = false;
            Response = 0;
            TimeSpent = 0 + elapsed;
            DisplayTimer = displayTimer;
            FillWithSpace();
            StartTimer();
            ParseMap(l);
        }

        private void ParseMap(IEnumerable<string> l)
        {
            foreach (string s in l)
            {
                string[] n = s.Split(';');

                int x = int.Parse(n[0]);
                int y = int.Parse(n[1]);
                string type = n[2];

                switch (type)
                {
                    case "PLAYERSPAWN":
                        SetCharTo(x, y, 'x');
                        PlayerPos = (x, y);
                        break;
                    case "TEXT":
                        string text = n[3];
                        int textLen = text.Length;

                        for (int i = 0; i < textLen; i++)
                        {
                            SetCharTo(x + i, y, text[i]);
                        }
                        break;
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
                    case "WALL":
                        SetCharTo(x, y, char.Parse(n[3]));
                        break;
                    case "FINISHLEVEL":
                        SetCharTo(x, y, 'C');
                        break;
                    case "CRYSTAL":
                        SetCharTo(x, y, '*');
                        break;
                }
            }
        }

        private async void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TickTime;
            timer.Enabled = true;
        }

        private void TickTime(Object source, System.Timers.ElapsedEventArgs e) { 
            TimeSpent += 1;

            if (DisplayTimer)
            {
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top-2);
                Console.WriteLine($"Eltelt idő: {TimeFormats.FormatSeconds(getTimeSpent())}");
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
            }
        }

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
            if (DisplayTimer)
            {
                Console.WriteLine($"Eltelt idő: {TimeFormats.FormatSeconds(getTimeSpent())}");
            }
            else { Console.WriteLine(); }
            Console.WriteLine();
        }

        public void SetCharTo(int x, int y, char c)
        {
            Area[x, y] = c;
        }

        public bool isFinished()
        {
            return IsFinished;
        }

        public int getResponse()
        {
            return Response;
        }

        public int getTimeSpent() {
            return TimeSpent; 
        }

        public void setResponseDefault()
        { Response = 0; }

        public void movePlayer(int x, int y)
        {
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
                // Wall
                else if (c == '@')
                {
                    return;
                }
                // Crystal
                else if (c == '*') 
                {
                    Response = 3;
                }
                // Finish Level Character
                else if (c == 'C')
                {
                    IsFinished = true;
                    timer.Enabled = false;

                }
                else
                {
                    SetCharTo(PlayerPos.x, PlayerPos.y, ' ');
                    SetCharTo(x, y, 'x');
                    PlayerPos = (x, y);
                }
            }
        }

        public void HandleKey()
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            cki = Console.ReadKey(true);

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
            }
        }
    }
}
