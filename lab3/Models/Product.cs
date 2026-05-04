using lab3.CustomValidators;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters")]
        [MaxLength(200, ErrorMessage = "Maximum length is 200 character")]
        [Remote("IsTitleAvailable", "Product", ErrorMessage = "Title already exists")]
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

        [MaxLength(255)]
        public string? ImageName { get; set; }
        public virtual Category? Category { get; set; }
    }
}