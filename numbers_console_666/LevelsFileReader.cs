using Newtonsoft.Json;

namespace Client
{
    internal class LevelsFileReader
    {
        //internal List<List<int>> Read()
        //{
        //    var path = Pathes.LevelsPath;
        //    var json = File.ReadAllText(path);
        //    var levels = JsonConvert.DeserializeObject<List<List<int>>>(json);
        //    return levels;
        //}
        public List<Solution> ReadAllSolutions()
        {
            var path = Pathes.LevelsPath;
            var json = File.ReadAllText(path);
            var levels = JsonConvert.DeserializeObject<List<Solution>>(json);
            return levels;
        }
    }
}
