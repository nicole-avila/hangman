using System;
using Spectre.Console;
using Figgle;

namespace hangmanGame
{
    public class UserInterface
    {
        public void DisplayTitle()
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Hangman").Centered().Color(Color.Yellow));
            AnsiConsole.Write(new Rule("[bold red]Welcome to Hangman![/]").RuleStyle("grey"));
        }

        public void MainMenu()
        {
            Console.WriteLine("\nPlease select an option:");
            AnsiConsole.MarkupLine("[green]1. Play Game[/]");
            AnsiConsole.MarkupLine("[blue]2. Add New Word[/]");
            AnsiConsole.MarkupLine("[red]3. Exit[/]");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowWordSaved()
        {
            Console.WriteLine("The word has been saved!");
        }
    }
}