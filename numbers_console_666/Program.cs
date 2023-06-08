using System.Xml.Linq;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            var levelsReader = new LevelsFileReader();

            var allLevels = levelsReader.ReadAllSolutions();

            var game = new Game(allLevels);

            while (game.isPlaying())
            {
                game.Play();
            }
        }
    }
}