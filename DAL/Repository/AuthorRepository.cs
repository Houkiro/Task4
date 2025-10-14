using Core.Entities.Model;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    }
}
