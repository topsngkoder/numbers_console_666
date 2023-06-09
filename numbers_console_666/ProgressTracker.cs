namespace Client
{
    public class ProgressTracker
    {
        private List<int> _completeLevels = new List<int>();

        public List<int> GetCompleteLevels()
        {
            return _completeLevels;
        }

        public void LevelComlete(int level)
        {
            _completeLevels.Add(level);
        }

        public bool IsLevelCopmplete(int level)
        {
            return _completeLevels.Contains(level);
        }
    }
}