using System.Collections.Concurrent;

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

                var userInput = Console.ReadKey(true).KeyChar;

                switch (userInput)
                {
                    case '1':
                        _gameService.StartGame(_ui);
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
                        Console.WriteLine("Invalid userInput. Please try again.");
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
 
        private void AddNewWord()
        {
            _ui.DisplayTitle();
            while (true) 
            {
                Console.Write("\nEnter a new word to add (3-11 characters, letters only): ");
                string newWord = (Console.ReadLine() ?? string.Empty).Trim();

                Console.WriteLine("Attempting to add word: " + newWord);

                var success = _wordProvider.AddWord(newWord);

                if(success)
                {
                    _ui.ShowWordSaved();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Do you want to try again or go back to the menu? Use the menu to navigate");
                }

                Console.WriteLine("1. Try again");
                Console.WriteLine("2. Go back to menu");
                var userInput = Console.ReadKey(true).KeyChar;
                switch (userInput)
                {
                    case '1':
                        break;
                    case '2':
                        return;
                    default:
                        Console.WriteLine("Invalid userInput. Please try again.");
                    continue;
                }
            }
        }
    }
}