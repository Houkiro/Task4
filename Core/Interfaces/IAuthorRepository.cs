using Core.Entities.Model;

namespace Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync(bool trackChanges);

        Task<Author> GetByIdAsync(int id, bool trackChanges);

        void CreateAsync(Author author);

        void DeleteAsync(Author author);

        Task<IEnumerable<Author>> GetAllWithBooksAsync(bool trackChanges);

        Task<IEnumerable<Author>> GetAuthorsWithBooksAfterYearAsync(int year, bool trackChanges);

        Task<IEnumerable<Author>> FindAuthorsByNameAsync (string namePart, bool trackChanges);
    }
}