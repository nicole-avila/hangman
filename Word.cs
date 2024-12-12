using FluentValidation;

namespace hangmanGame
{

    public class Word<T>
    {
        private T _value;

        public Word(T value)
        {
            _value = value;
        }

        public T GetValue => _value;
    }

    public class WordValidator<T> : AbstractValidator<Word<T>>
    {
        public WordValidator(List<Word<string>> existingWords)
        {
            RuleFor(word => word.GetValue).NotEmpty().WithMessage("Word should not be empty");
            RuleFor(word => word.GetValue as string).Matches(@"^[a-zA-Z]+$").WithMessage("Word must contain only letters.");
            RuleFor(word => word.GetValue as string).Length(3, 11).WithMessage("Word length must be between 3 and 11");
            RuleFor(word => word.GetValue as string).Must(word => {

                var exists = existingWords.Any(existingWord => existingWord.GetValue == word);

                return exists ? false : true;
            }).WithMessage("Word already exists"); 
        }
    }
}