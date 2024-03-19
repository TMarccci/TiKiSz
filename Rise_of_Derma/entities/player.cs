namespace Rise_of_Derma.entities
{
    class Player : Entity
    {
        private int crystalCount = 0;

        public void addCrystal(int crystal) { this.crystalCount++; }
        public void removeCrystal(int crystal) { this.crystalCount--; }
        public int getCrystalCount() { return crystalCount; }

        public Player() { this.setAppearanceTo('X'); }
    }
}
