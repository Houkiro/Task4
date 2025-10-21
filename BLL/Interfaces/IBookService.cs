using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllBooksForAuthorAsync(int authorId);

        Task<BookResponseDto> GetBooksForAuthorByIdAsync(int authorId, int id);

        Task<BookResponseDto> CreateBookForAuthor(int authorId, CreateBookModelDto book);

        Task UpdateBookForAuthorAsync(int authorId, int id, UpdateBookModelDto book);

        Task DeleteBookForAuthorAsync(int authorId, int id);
    }
}