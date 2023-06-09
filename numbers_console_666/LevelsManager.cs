using System.Collections.Generic;
using System.Linq.Expressions;

namespace Client
{
    public class LevelsManager
    {
        private readonly ProgressTracker _progressTracker;
        private List<Level> _allLevels = new List<Level>();
        Random _random = new Random();

        public LevelsManager(List<Level> levels, ProgressTracker progressTracker)
        {
            _allLevels = levels;
            _progressTracker = progressTracker;
        }

        public Level GetCurrentSolution()
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