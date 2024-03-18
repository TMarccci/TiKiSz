using Rise_of_Derma.fields;
using System;

namespace Rise_of_Derma.scenarios
{
    class Scenario
    {
        public Level CurrentLevel { get; set; }

        public Scenario()
        {
            CurrentLevel = GenerateScenario();
        }

        // Virtual Level, get's overwritten by the sample scenario
        public virtual Level GenerateScenario()
        {
            Level level = new Level();

            return level;
        }

        public virtual void ProcessInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    CurrentLevel.moveEntity(0, CurrentLevel.entities[0].getPosX() - 1, CurrentLevel.entities[0].getPosY());
                    break;
                case ConsoleKey.RightArrow:
                    CurrentLevel.moveEntity(0, CurrentLevel.entities[0].getPosX() + 1, CurrentLevel.entities[0].getPosY());
                    break;
                case ConsoleKey.DownArrow:
                    CurrentLevel.moveEntity(0, CurrentLevel.entities[0].getPosX(), CurrentLevel.entities[0].getPosY() + 1);
                    break;
                case ConsoleKey.UpArrow:
                    CurrentLevel.moveEntity(0, CurrentLevel.entities[0].getPosX(), CurrentLevel.entities[0].getPosY() - 1);
                    break;
            }

            // Check for level completion
            if (IsLevelCompleted())
            {
                HandleLevelCompletion();
            }
        }

        protected virtual bool IsLevelCompleted()
        {
            // Implement the logic to check if the level is completed
            // Return true if completed, false otherwise
            return false;
        }

        protected virtual void HandleLevelCompletion()
        {
            // Implement the logic to handle level completion
            // This could include creating and setting up the next scenario
        }
    }
}
