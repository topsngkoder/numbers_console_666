namespace Client
{
    public class ProgressTracker
    {
        private List<int> _completeLevels = new List<int>();

        public List<int> GetCompleteLevels()
        {
            return _completeLevels;
        }

        public void LevelComlete(int levelHashCode)
        {
            _completeLevels.Add(levelHashCode);
        }
    }
}