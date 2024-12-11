using Newtonsoft.Json;

namespace hangmanGame
{
    public class WordManager<T>
    {
        private readonly string _filePath;

        public WordManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> LoadWordsData()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonConvert.DeserializeObject<WordsData<T>>(json);
                return data?.Words ?? new List<T>();
            }
                return new List<T>();
        }

        public void SaveWordsData(List<T> words)
        {
            var data = new WordsData<T> { Words = words };
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
    public class WordsData<T>
    {
        public List<T> Words { get; set; } = new List<T>();
    }
}