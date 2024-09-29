
using FluentValidation.Results;

namespace Teste.Domain.Extension
{
    public static class ValidationExtension
    {
        public static string ToMessageErros(this ValidationResult validationResult)
        {
            string errorMessage = string.Empty;
            if (validationResult != null)
            {
                foreach (var error in validationResult.Errors)
                {
                    errorMessage += $"PropertyName = {error.PropertyName}, Error = {error.ErrorMessage}";
                }
            }

            return errorMessage;
        }
    }
}
