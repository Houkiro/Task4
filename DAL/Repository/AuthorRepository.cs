using DAL.Entities.Model;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Author>> GetAllAsync() =>
            await FindAll().OrderBy(a => a.Name).ToListAsync();

        public async Task<Author> GetByIdAsync(int id) =>
            await FindByCondition(a => a.Id.Equals(id)).SingleOrDefaultAsync();

        public void CreateAsync(Author author) => Create(author);

        public void DeleteAsync(Author author) => Delete(author);


        public async Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync() =>
            await FindAll().OrderByDescending(a => a.Books.Count).ToListAsync();

        public async Task<IEnumerable<Author>> GetAllWithBooksAsync() =>
            await FindAll()
                  .Include(a => a.Books)
                  .ToListAsync();

        public async Task<IEnumerable<Author>> GetAuthorsWithBooksAfterYearAsync(int year) =>
            await FindAll().Where(a => a.Books.Any(b => b.PublishedYear > year)).ToListAsync();

        public async Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart) =>
            await FindAll().Where(a => a.Name.Contains(namePart)).ToListAsync();
    }
}