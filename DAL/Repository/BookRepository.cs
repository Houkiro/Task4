using DAL.Entities.Model;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(int authorId) =>
            await FindAll().Where(b => b.AuthorId == authorId)
            .OrderBy(b => b.Title)
            .ToListAsync();

        public async Task<Book?> GetBookByAuthorIdAsync(int authorId, int id) =>
            await FindByCondition(b => b.AuthorId.Equals(authorId) && b.Id.Equals(id))
            .SingleOrDefaultAsync();

        public void CreateAsync(int authorId, Book book)
        {
            book.AuthorId = authorId;
            Create(book);
        }

        public void DeleteAsync(Book book) => Delete(book);
    }
}