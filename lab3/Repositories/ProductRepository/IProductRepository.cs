using lab3.Models;

namespace lab3.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int? categoryId = null);
        Product? GetById(int id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        int Save();
        bool IsTitleExists(string title, int excludeId = 0);
    }
}
