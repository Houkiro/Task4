using Core.Entities.Model;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(int authorId);
        Task<Book?> GetBookByAuthorIdAsync(int authorId, int id);
        Task<Book> CreateAsync(int authorId, Book book);
        Task UpdateAsync(int authorId, int id, Book book);
        Task DeleteAsync(int authorId, int id);
    }
}