using DAL.Entities.Model;

namespace DAL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();

        Task<Author> GetByIdAsync(int id);

        void Create(Author author);

        void Delete(Author author);

        Task<IEnumerable<Author>> GetAllWithBooksAsync();

        Task<IEnumerable<Author>> GetAuthorsWithBooksAfterYearAsync(int year);

        Task<IEnumerable<Author>> FindAuthorsByNameAsync (string namePart);
    }
}