namespace Rise_of_Derma.entities
{
    public class Player
    {
        public int Power { get; set; }
        public int KilledEnemy { get; set; }
        public int CrystcalCount { get; set; }

        public Player(int power, int killedEnemy, int crystalCount)
        {
            Power = power;
            KilledEnemy = killedEnemy;
            CrystcalCount = crystalCount;
        }

        public Player() 
        {
            Power = 1;
            KilledEnemy = 0;
            CrystcalCount = 0;
        }
    }
}