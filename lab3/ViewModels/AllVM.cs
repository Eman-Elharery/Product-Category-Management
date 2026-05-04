using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3.ViewModels
{
    public class AllVM
    {
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();
    }
}
