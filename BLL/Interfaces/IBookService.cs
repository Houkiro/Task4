using Shared.DTO;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksForAuthorAsync(int authorId);
        Task<BookDto> GetBooksForAuthorByIdAsync(int authorId, int id);
        Task<BookDto> CreateBookForAuthor(int authorId, BookDto book);
        Task<BookDto> UpdateBookForAuthorAsync(int authorId, int id, BookDto book);
        Task<bool> DeleteBookForAuthor(int authorId, int id);
    }
}