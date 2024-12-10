using System;
using System.IO;
using System.Collections.Generic;

namespace hangmanGame
{
    public class FileWordProvider : IWordProvider
    {
        private readonly WordManager _repository;
        private List<string> _words;

        public FileWordProvider(string filePath)
        {
            _repository = new WordManager(filePath);
            _words = _repository.LoadWords();
        }

        public string GetWord()
        {
            Random random = new Random();
            return _words[random.Next(_words.Count)].Trim();
        }

        public void AddWord(string newWord)
        {
            if (string.IsNullOrWhiteSpace(newWord) || _words.Contains(newWord.Trim()))
            {
                Console.WriteLine("Invalid or duplicate word.");
                return;
            }
            
            _words.Add(newWord);
            _repository.SaveWords(_words);
            Console.WriteLine($"Added word: {newWord}");
        }
    }
}