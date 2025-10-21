using DAL.Entities.Model;

namespace DAL.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(int authorId);

        Task<Book?> GetBookByAuthorIdAsync(int authorId, int id);

        void CreateAsync(int authorId, Book book);

        void DeleteAsync(Book book);
    }
}