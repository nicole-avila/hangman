using FluentValidation;

namespace hangmanGame
{

    public class Word : IWordProvider
    {
        public required string Value { get; set; }
        public string GetWord() => Value;
        public bool AddWord(string newWord) => false;
    }

    public class WordValidator : AbstractValidator<Word>
    {
        public WordValidator()
        {
            RuleFor(word => word.Value).NotEmpty().WithMessage("Word should not be empty");
            RuleFor(word => word.Value).Length(3, 11).WithMessage("Word length must be between 3 and 11");
            RuleFor(word => word.Value).Matches(@"^[a-zA-Z]+$").WithMessage("Word must contain only letters.");
        }
    }
}