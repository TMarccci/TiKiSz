namespace Rise_of_Derma.entities
{
    class Entity
    {
        private int health = 100;
        private char appearance;
        private int power = 1;

        private int prevPosX;
        private int prevPosY;
        private int posX;
        private int posY;

        public void damage(int amount)
        {
            this.health -= amount;
        }
        public void regenerate(int amount)
        {
            this.health += amount;
        }
        public void setHealthTo(int amount)
        {
            this.health = amount;
        }
        public int getHealth() { return this.health; }

        public void setAppearanceTo(char value)
        {
            this.appearance = value;
        }
        public char getAppearance() { return this.appearance; }

        public void weaken(int amount)
        {
            this.power -= amount;
        }
        public void strenghten(int amount)
        {
            this.power += amount;
        }
        public void setPowerTo(int amount)
        {
            this.power = amount;
        }
        public int getPower() { return this.power; }

        public int getPrevPosX() { return prevPosX; }
        public int getPrevPosY() { return prevPosY; }
        public int getPosX() { return posX; }
        public int getPosY() { return posY; }

        public void moveEntityProperties(int prevPosX, int prevPosY, int posX, int posY)
        {
            this.prevPosX = prevPosX;
            this.prevPosY = prevPosY;
            this.posX = posX;
            this.posY = posY;
        }
    }
}