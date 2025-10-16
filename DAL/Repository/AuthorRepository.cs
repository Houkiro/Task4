using Core.Entities.Model;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;

namespace DAL.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<IEnumerable<Author>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(a => a.Name).ToListAsync();
        public async Task<Author> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(a => a.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        public void CreateAsync(Author author) => Create(author);
        public void DeleteAsync(Author author) => Delete(author);

        public async Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync(bool trackChanges) => 
            await FindAll(trackChanges).OrderByDescending(a => a.Books.Count).ToListAsync();
        public async Task<IEnumerable<Author>> GetAllWithBooksAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                  .Include(a => a.Books)
                  .ToListAsync();

        public async Task<IEnumerable<Author>> GetAuthorsWithBooksAfterYearAsync(int year, bool trackChanges) =>
            await FindAll(trackChanges).Where(a => a.Books.Any(b => b.PublishedYear > year)).ToListAsync();

        public async Task<IEnumerable<Author>> FindAuthorsByNameAsync(string namePart, bool trackChanges) =>
            await FindAll(trackChanges).Where(a => a.Name.Contains(namePart)).ToListAsync();
    }
}