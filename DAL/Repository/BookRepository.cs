using Core.Entities.Model;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(int authorId, bool trackChanges) =>
            await FindAll(trackChanges).Where(b => b.AuthorId == authorId)
            .OrderBy(b => b.Title)
            .ToListAsync();

        public async Task<Book?> GetBookByAuthorIdAsync(int authorId, int id, bool trackChanges) =>
            await FindByCondition(b => b.AuthorId.Equals(authorId) && b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateAsync(int authorId, Book book)
        {
            book.AuthorId = authorId;
            Create(book);
        }

        public void DeleteAsync(Book book) => Delete(book);
    }
}