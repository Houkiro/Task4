using Core.Entities.Model;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(int authorId, bool trackChanges);

        Task<Book?> GetBookByAuthorIdAsync(int authorId, int id, bool trackChanges);

        void CreateAsync(int authorId, Book book);

        void DeleteAsync(Book book);
    }
}