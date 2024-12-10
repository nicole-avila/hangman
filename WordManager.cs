using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace hangmanGame
{
    public class WordManager
    {
        private readonly string _filePath;

        public WordManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<string> LoadWords()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonConvert.DeserializeObject<WordsData>(json);
                return data?.Words ?? new List<string>();
            }
            return new List<string>();
        }

        public void SaveWords(List<string> words)
        {
            var data = new WordsData { Words = words };
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}