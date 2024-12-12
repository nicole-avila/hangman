namespace hangmanGame
{
    public interface IWordProvider
    {
        Word<string> GetWord();
        bool AddWord(string newWord);
    }
}