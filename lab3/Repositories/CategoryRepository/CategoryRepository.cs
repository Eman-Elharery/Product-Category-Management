using lab3.Data.Context;
using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) => _context = context;

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public int Save() => _context.SaveChanges();
    }
}