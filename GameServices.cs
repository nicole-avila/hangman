namespace hangmanGame
{
    public class GameService
    {
        private readonly IWordProvider _wordProvider;
        private List<char> _guessedLetters = new();
        private int _remainingAttempts = 7;
        private string _currentWord = string.Empty;

        public GameService(IWordProvider wordProvider)
        {
            _wordProvider = wordProvider;
        }

        public void StartGame()
        {
            _currentWord = _wordProvider.GetWord();
            _guessedLetters.Clear();
            _remainingAttempts = 7;

            Console.WriteLine("Game Started!");

            while (_remainingAttempts > 0 && !IsWordGuessed())
            {
                Console.WriteLine($"Guessed letters: {string.Join(", ", _guessedLetters)}");
                Console.WriteLine($"Current Word: {GetMaskedWord()}");
                Console.Write("Enter your guess: ");

                char guess = char.ToLower(Console.ReadKey().KeyChar); 
                Console.WriteLine();

                  if (!char.IsLetter(guess))
                {
                    Console.WriteLine("Please enter a valid letter.");
                    continue;
                }

                if (_guessedLetters.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter.");
                    continue;
                }

                _guessedLetters.Add(guess);

                if (!_currentWord.Contains(guess))
                {
                    _remainingAttempts--;
                    Console.WriteLine($"Incorrect! Attempts remaining: {_remainingAttempts}");
                }
            }

            if (IsWordGuessed())
            {
                Console.WriteLine($"Congratulations! You've guessed the word: {_currentWord}");
            }
            else
            {
                Console.WriteLine($"Game over! \n---The word was: {_currentWord}---");
                Console.WriteLine("Would you like to try again? (y/n)");
            }
        }

        private bool IsWordGuessed() => _currentWord.All(c => _guessedLetters.Contains(c));
        private string GetMaskedWord() => new string(_currentWord.Select(c => _guessedLetters.Contains(c) ? c : '_').ToArray());
    }
}