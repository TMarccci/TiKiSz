using Rise_of_Derma.entities;
using Rise_of_Derma.entities.constants;
using Rise_of_Derma.providers;

namespace Rise_of_Derma.fields
{
    class Level : Map
    {
        // Values
        public char[,] area;
        public List<Entity> entities = new List<Entity>();
        
        public Level()
        // Fill area with empty ' '-s
        {
            area = new char[this.W, this.H];
            for (int i = 0; i < this.W; i++)
            {
                for (int j = 0; j < this.H; j++)
                {
                    area[i, j] = ' ';
                }
            }
        }

        // Display level function
        public void display()
        {
            

            for (int i = 0; i <= this.W + 1; i++)
            {
                if (i == this.W + 1)
                {
                    FastConsole.WriteLine("_");
                }
                else
                {
                    FastConsole.Write("_");
                }
            }

            for (int mag = 0; mag < this.H; mag++)
            {
                FastConsole.Write("|");
                for (int szel = 0; szel < this.W; szel++)
                {
                    FastConsole.Write($"{area[szel, mag]}");
                }
                FastConsole.WriteLine("|");
            }

            for (int i = 0; i < this.W + 2; i++)
            {
                if (i == this.W + 2)
                {
                    FastConsole.WriteLine("‾");
                }
                else
                {
                    FastConsole.Write("‾");
                }
            }
            FastConsole.WriteLine("");
            FastConsole.Flush();
        }

        // Move entity (inside properties and visually also)
        public void moveEntity(int entityInd, int x, int y)
        {
            Entity ent = entities[entityInd];

            // Verify that entity can't leave map
            // On: X
            if (0-1 < x && x < this.W)
            {
                // On: Y
                if (0-1 < y && y < this.H)
                {
                    // Verify that if the new position is a wall
                    if (area[x, y] != '#')
                    {
                        // Verify that if the new position is a crystal, if it than handle
                        if (area[x, y] != '*')
                        {
                            ent.moveEntityProperties(ent.getPosX(), ent.getPosY(), x, y);

                            area[ent.getPrevPosX(), ent.getPrevPosY()] = ' ';
                            area[x, y] = ent.getAppearance();

                            this.display();
                        } 
                    }
                }
            }
        }
    }
}
