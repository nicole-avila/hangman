namespace hangmanGame
{
    public class FileWordProvider : IWordProvider
    {
        private readonly WordManager<string> _wordManager;

        public FileWordProvider(string filePath)
        {
            _wordManager = new WordManager<string>(filePath);
        }

        public string GetWord()
        {
            var words = _wordManager.LoadWordsData();
            if (words.Count == 0)
                throw new InvalidOperationException("No words available. Add some words first.");

            var random = new Random();
            return words[random.Next(words.Count)].Trim();
        }

      
        public bool AddWord(string newWord) 
        {
            newWord = newWord.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(newWord))
            {
                Console.WriteLine("The word cannot be empty.");
                return false; 
            }

            var words = _wordManager.LoadWordsData();
            // if (words.Contains(newWord))
            // {
            //     Console.WriteLine("The word already exists.");
            //     return false; 
            // }

            words.Add(newWord);
            _wordManager.SaveWordsData(words);
            Console.WriteLine($"Added word: {newWord}");
            return true;
        }
    }
}