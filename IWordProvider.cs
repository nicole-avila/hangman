namespace hangmanGame
{
    public interface IWordProvider
    {
        string GetWord();
        void AddWord(string newWord);
    }
}