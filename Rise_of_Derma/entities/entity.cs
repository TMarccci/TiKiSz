namespace Rise_of_Derma.entities
{
    public class Entity
    {
        private int health = 100;
        private int posX;
        private int posY;

        public int Health 
        { 
            get { return health; }
            set { health = (value <= 100 && value > 0) ? value : 100; } 
        }
        public char Appearance { get; set; }
        public int Power { get; set; }

        public int PosX 
        { 
            get { return posX; }
            set { posX = (value < 80 && value >= 0) ? value : 0 ; } 
        }
        public int PosY
        {
            get { return posY; }
            set { posY = (value < 20 && value >= 0) ? value : 0; }
        }

        public Entity(int health, char appearance, int power, int posX, int posY)
        {
            Health = health;
            Appearance = appearance;
            Power = power;
            PosX = posX;
            PosY = posY;
        }
    }
}