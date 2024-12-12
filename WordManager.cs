using FluentValidation.Results;
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

        public List<Word<string>> LoadWordsData()
        {
            if(!File.Exists(_filePath)){
                return new List<Word<string>>();
            }
            
            var json = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<List<string>>(json);

            var wordData = data?.Select(element => new Word<string>(element)).ToList() ?? new List<Word<string>>();
            return wordData;
        }

        public void SaveWordsData(List<Word<string>> words)
        {
            var data = new List<string>();
            words.ForEach(word => data.Add(word.GetValue));

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public ValidationResult IsValidWord(Word<string> word)
        {
            var wordData = LoadWordsData();

            var validator = new WordValidator<string>(wordData);
            return validator.Validate(word);
        }
    }
}