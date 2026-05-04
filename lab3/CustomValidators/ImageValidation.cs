using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace lab3.CustomValidators
{
    public class ImageValidationAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;
        private readonly int _maxFileSize;

        public ImageValidationAttribute(string[] allowedExtensions, int maxFileSizeMB)
        {
            _allowedExtensions = allowedExtensions;
            _maxFileSize = maxFileSizeMB * 1024 * 1024; 
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file == null)
                return ValidationResult.Success; 

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!_allowedExtensions.Contains(extension))
                return new ValidationResult($"Only {string.Join(", ", _allowedExtensions)} are allowed.");

            if (file.Length > _maxFileSize)
                return new ValidationResult($"Maximum allowed size is {_maxFileSize / (1024 * 1024)} MB.");

            return ValidationResult.Success;
        }
    }
}