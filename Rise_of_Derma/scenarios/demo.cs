using Rise_of_Derma.entities;
using Rise_of_Derma.entities.constants;

namespace Rise_of_Derma.scenarios
{
    class DemoScenario : Scenario
    {
        public DemoScenario() : base()
        {
            // Add specific entities and their positions for the demo scenario
            CurrentLevel.entities.Add(new Player());

            int p1Id = 0;
            Player p1 = (Player)CurrentLevel.entities[p1Id];
            CurrentLevel.moveEntity(p1Id, 20, 7);

            int crystalId = 1;
            CurrentLevel.entities.Add(new Crystal());
            CurrentLevel.moveEntity(crystalId, 20, 11);

            for (int i = 2; i < 12; i++)
            {
                CurrentLevel.entities.Add(new Wall());
                CurrentLevel.moveEntity(i, 13, i + 5);
            }

            // The next entity id is 13
        }
    }
}
