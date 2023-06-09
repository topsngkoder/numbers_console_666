using System.Collections.Generic;
using System.Linq.Expressions;

namespace Client
{
    public class LevelsManager
    {
        private List<Solution> _allLevels = new List<Solution>();

        public LevelsManager(List<Solution> levels)
        {
            _allLevels = levels;
        }

        Random _random = new Random();

        private ProgressTracker _progressTracker = new ProgressTracker();

        public Solution GetCurrentSolution()
        {


            var completedLevels = _progressTracker.GetCompleteLevels();

            var validLevels = _allLevels.Where(solution =>
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
            
            int nextLevel = _random.Next(0, validLevelsCount);
                        
            return validLevels[nextLevel];
        }



    }

}