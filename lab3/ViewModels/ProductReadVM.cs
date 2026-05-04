using lab3.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace lab3.ViewModels
{
    public class ProductReadVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }

        [MaxLength(255)]
        public string? ImageName { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}