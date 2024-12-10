using FluentValidation;

namespace hangmanGame
{

    public class Word : IWordProvider
    {
        public string Value { get; set; }
        public string GetWord() => Value;
        public void AddWord(string word) => Value = word;
    }

    public class WordValidator : AbstractValidator<Word>
    {
        public WordValidator()
        {
            RuleFor(word => word.Value).NotEmpty().WithMessage("Word should not be empty");
            RuleFor(word => word.Value).Length(1, 11).WithMessage("Word length must be between 1 and 11");
        }
    }
}