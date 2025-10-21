using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseDto>> GetAllAsync();

        Task<AuthorResponseDto> GetByIdAsync(int id);

        Task<AuthorResponseDto> CreateAsync(CreateAuthorModelDto author);

        Task UpdateAsync(int id, UpdateAuthorModelDto author);

        Task DeleteAsync(int id);

        Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync();

        Task<IEnumerable<AuthorResponseDto>> GetAuthorsWithBooksAfterYearAsync(int year);

        Task<IEnumerable<AuthorResponseDto>> FindAuthorsByNameAsync(string namePart);
    }
}