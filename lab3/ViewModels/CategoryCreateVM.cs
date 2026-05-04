using System.ComponentModel.DataAnnotations;

namespace lab3.ViewModels
{
    public class CategoryCreateVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters")]
        [MaxLength(200, ErrorMessage = "Maximum length is 200 characters")]
        public string Name { get; set; }
    }
}