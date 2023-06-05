
using Newtonsoft.Json;

namespace Client
{
    public class LevelsFileWriter
    {
        //public async void Write(List<List<int>> levels)
        //{
        //    var path = Pathes.LevelsPath;
        //    var json = JsonConvert.SerializeObject(levels);
        //    await File.WriteAllTextAsync(path, json);
        //}
        
        public async void Write(List<Solution> levels)
        {
            var path = Pathes.LevelsPath;
            var json = JsonConvert.SerializeObject(levels);
            await File.WriteAllTextAsync(path, json);
        }
    }
}