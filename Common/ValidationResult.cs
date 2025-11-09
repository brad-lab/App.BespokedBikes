
namespace App.BespokedBikes.Application.Common
{
    public sealed class ValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public static readonly ValidationResult Success = new ValidationResult(true, string.Empty);

        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage ?? string.Empty;
        }
    }
}