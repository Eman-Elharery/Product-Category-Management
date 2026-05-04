using System.ComponentModel.DataAnnotations;

namespace lab3.CustomValidators
{
    public class ExpiryDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Expiry date is required");

            if (value is not DateTime expiryDate)
                return new ValidationResult("Invalid date format");

            var today =DateTime.Today;

            if (expiryDate > today)
                return new ValidationResult("Expiry date cannot be in the future");

            return ValidationResult.Success;
        }
    }
}