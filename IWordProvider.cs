namespace hangmanGame
{
    public interface IWordProvider
    {
        string GetWord();
        bool AddWord(string newWord);
    }
}