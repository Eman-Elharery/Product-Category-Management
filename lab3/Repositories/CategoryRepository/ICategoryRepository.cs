using lab3.Models;

namespace lab3.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        int Save();
    }
}
