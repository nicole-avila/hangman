namespace hangmanGame
{
    public class FileWordProvider : IWordProvider
    {
        private readonly WordManager<string> _wordManager;

        public FileWordProvider(string filePath)
        {
            _wordManager = new WordManager<string>(filePath);
        }

        public Word<string> GetWord()
        {
            var words = _wordManager.LoadWordsData();
            if (words.Count == 0)
                throw new InvalidOperationException("No words available. Add some words first.");

            var random = new Random();
            return words[random.Next(words.Count - 1)];
        }

      
        public bool AddWord(string newWord) 
        {
            var trimmedValue = newWord.Trim().ToLower();

            var words = _wordManager.LoadWordsData();

            var trimmedWord = new Word<string>(trimmedValue);

            var validationResult = _wordManager.IsValidWord(trimmedWord);
            
            if(!validationResult.IsValid){
                validationResult.Errors.ForEach(error => Console.WriteLine(error.ErrorMessage));
                return false;
            }

            words.Add(trimmedWord);

            _wordManager.SaveWordsData(words);
            Console.WriteLine($"Added word: {newWord}");
            return true;
        }
    }
}