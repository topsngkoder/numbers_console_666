using System.Xml.Linq;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            var allLevels = new LevelsFileReader();
            Random random = new Random();

            ProgressTracker progressTracker = new ProgressTracker();

            int currentLevel = 0;

            Game game = new Game(allLevels.ReadAllSolutions());
            
            while (!game.EndGame())
            {
                game.Play(currentLevel);
                progressTracker.LevelComlete(currentLevel);
                currentLevel++;
            }
        }



    }
}