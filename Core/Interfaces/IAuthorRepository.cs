using Core.Entities.Model;

namespace Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task UpdateAsync(int id, Author author);
        Task DeleteAsync(int id);
    }
}
