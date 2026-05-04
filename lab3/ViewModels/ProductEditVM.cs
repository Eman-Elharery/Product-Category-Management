using lab3.CustomValidators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace lab3.ViewModels
{
    public class ProductEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters")]
        [MaxLength(200, ErrorMessage = "Maximum length is 200 character")]
        [Remote("IsTitleAvailable", "Product", AdditionalFields = "Id")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Range(1, 1000000)]
        public decimal Price { get; set; }
        [Range(1, 1000000)]
        public int Count { get; set; }
        [Required]
        [ExpiryDate]
        public DateTime? ExpiryDate { get; set; }
        public int CategoryId { get; set; }
       
        public string? CategoryName { get; set; }

        [ImageValidation(new string[] { ".jpg", ".jpeg", ".png" }, 2)]
        public IFormFile? Image { get; set; }
        public string? ExistingImageName { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}