namespace Client
{
    public class Program
    {
        public static void Main()
        {
            var allLevels = new LevelsFileReader();

            int currentLevel = 0;

            Game game = new Game(allLevels.ReadAllSolutions());

            game.Start(currentLevel);
        }



    }
}