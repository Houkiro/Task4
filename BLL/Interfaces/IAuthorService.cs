using Core.Entities.Attributes.DTO;
using Shared.DTO;

namespace BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync(bool trackChanges);
        Task<AuthorDto> GetByIdAsync(int id, bool trackChanges);
        Task<AuthorDto> CreateAsync(AuthorDtoWithoutId author);
        Task UpdateAsync(int id, AuthorDtoWithoutId author, bool trackChanges);
        Task DeleteAsync(int id, bool trackChanges);
        Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync(bool trackChanges);
        Task<IEnumerable<AuthorDto>> GetAuthorsWithBooksAfterYearAsync(int year, bool trackChanges);
        Task<IEnumerable<AuthorDto>> FindAuthorsByNameAsync(string namePart, bool trackChanges);
    }
}