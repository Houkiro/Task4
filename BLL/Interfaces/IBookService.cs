using Shared.DTO;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksForAuthorAsync(int authorId, bool trackChanges);
        Task<BookDto> GetBooksForAuthorByIdAsync(int authorId, int id, bool trackChanges);
        Task<BookDto> CreateBookForAuthor(int authorId, BookDtoWithoutId book, bool trackChanges);
        Task UpdateBookForAuthorAsync(int authorId, int id, BookDtoWithoutId book, bool trackChanges);
        Task DeleteBookForAuthorAsync(int authorId, int id, bool trackChanges);
    }
}