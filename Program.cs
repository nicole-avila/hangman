namespace hangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
        FileWordProvider wordProvider = new FileWordProvider("words.json");
        GameService gameService = new GameService(wordProvider);

        UserInterface ui = new UserInterface();

        ui.DisplayTitle();

        DisplayInterface displayInterface = new DisplayInterface(gameService, ui, wordProvider);
        displayInterface.Start();
        }
    }
}