using System.Collections.Generic;
using System.Linq.Expressions;

namespace Client
{
    public class LevelsManager
    {
        private List<Solution> allLevels = new List<Solution>();

        public LevelsManager(List<Solution> levels)
        {
            allLevels = levels;
        }

        Random random = new Random();

        private ProgressTracker progressTracker = new ProgressTracker();

        public Solution GetCurrentSolution()
        {


            var completedLevels = progressTracker.GetCompleteLevels();

            var validLevels = allLevels.Where(solution =>
            {
                bool valid = !completedLevels.Contains(solution.GetHashCode());
                return valid;
            }
            ).ToList();


            int validLevelsCount = validLevels.Count();
            
            if (validLevelsCount <= 0)
            {
                throw new Exception("No availible levels");
            }
            
            int nextLevel = random.Next(0, validLevelsCount);
                        
            return validLevels[nextLevel];
        }



    }

}