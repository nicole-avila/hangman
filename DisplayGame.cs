namespace hangmanGame
{
    public class DisplayInterface
    {
    private readonly GameService _gameService;
    private readonly UserInterface _ui;
    private readonly FileWordProvider _wordProvider;

        public DisplayInterface(GameService gameService, UserInterface ui, FileWordProvider wordProvider)
        {
            _gameService = gameService;
            _ui = ui;
            _wordProvider = wordProvider;
        }

        public void Start()
        {
            while (true)
            {
                _ui.DisplayTitle();
                _ui.MainMenu();

                var choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case '1':
                        _gameService.StartGame();
                        if (AskToPlayAgain())
                        continue; 
                        break;
                    case '2':
                        AddNewWord();
                        break;
                    case '3':
                        Console.WriteLine("\nExiting game. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private bool AskToPlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            char answer = Console.ReadKey(true).KeyChar;
            return answer == 'y' || answer == 'Y';
        }

        //Fortästt här med felhanteringen.. Om ordet redan finns ge ett felmeddelande och be användaren att försöka igen.  
        private void AddNewWord()
        {
            while (true) 
            {
                Console.Write("\nEnter a new word to add (3-11 characters, letters only): ");
                string newWord = (Console.ReadLine() ?? string.Empty).Trim();

                var validator = new WordValidator();
                var validationResult = validator.Validate(new Word { Value = newWord });

                Console.WriteLine("Attempting to add word: " + newWord);

            
                if (validationResult.IsValid && newWord.Length >= 3 && newWord.Length <= 11)
                {
                
                    if (_wordProvider.AddWord(newWord))
                    {
                        _ui.ShowWordSaved();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("The word already exists."); 
                    }
                }
                else
                {
                    Console.WriteLine("Invalid word. Please try again.");
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                Console.WriteLine("Do you want to try again or go back to the menu? (Enter 'again' to try or press enter to return to menu)");

                string userInput = Console.ReadLine()!;
                if (userInput?.Trim().ToLower() != "again")
                {
                    break; 
                }
            }
        }
    }
}