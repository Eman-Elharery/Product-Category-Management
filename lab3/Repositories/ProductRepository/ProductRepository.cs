using lab3.Data.Context;
using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public IEnumerable<Product> GetAll(int? categoryId = null)
        {
            var query = _context.Products.Include(p => p.Category).AsQueryable();
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);
            return query.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public void Insert(Product product) => _context.Products.Add(product);

        public void Update(Product product) => _context.Products.Update(product);

        public void Delete(Product product) => _context.Products.Remove(product);

        public int Save() => _context.SaveChanges();
        public bool IsTitleExists(string title, int excludeId = 0)
        {
            return _context.Products.Any(p => p.Title == title && p.Id != excludeId);
        }
    }
}

