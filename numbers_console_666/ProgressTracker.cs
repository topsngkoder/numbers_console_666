namespace Client
{
    public class ProgressTracker
    {
        private List<int> completeLevels = new List<int>();

        public List<int> GetCompleteLevels()
        {
            return completeLevels;
        }


        public void LevelComlete(int level)
        {
            completeLevels.Add(level);
        }

        public bool IsLevelCopmplete(int level)
        {
            return completeLevels.Contains(level);
        }


    }
    
}