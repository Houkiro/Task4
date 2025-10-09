using Core.Entities.Model;
using Core.Interfaces;

namespace DAL.InMemoryRepository
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books;
        public InMemoryBookRepository()
        {
            _books = new List<Book>
            {
                new() { Id = 1, Title = "War and Peace", PublishedYear = 1869, AuthorId = 1 },
                new() { Id = 2, Title = "Anna Karenina", PublishedYear = 1877, AuthorId = 1 },
                new() { Id = 3, Title = "The Death of Ivan Ilyich", PublishedYear = 1886, AuthorId = 1 },

                new() { Id = 4, Title = "Crime and Punishment", PublishedYear = 1866, AuthorId = 2 },
                new() { Id = 5, Title = "The Brothers Karamazov", PublishedYear = 1880, AuthorId = 2 },
                new() { Id = 6, Title = "The Idiot", PublishedYear = 1869, AuthorId = 2 },

                new() { Id = 7, Title = "Pride and Prejudice", PublishedYear = 1813, AuthorId = 3 },
                new() { Id = 8, Title = "Sense and Sensibility", PublishedYear = 1811, AuthorId = 3 },
                new() { Id = 9, Title = "Emma", PublishedYear = 1815, AuthorId = 3 }
            };
        }
        public Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(int authorId)
        {
            var books = _books.Where(b => b.AuthorId == authorId);
            return Task.FromResult(books.AsEnumerable());
        }

        public Task<Book?> GetBookByAuthorIdAsync(int authorId, int id)
        {
            var book = _books.FirstOrDefault(b => b.AuthorId == authorId && b.Id == id);
            return Task.FromResult(book);
        }

        public Task<Book> CreateAsync(int authorId, Book book)
        {
            book.AuthorId = authorId;
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);

            return Task.FromResult(book);
        }
        public Task UpdateAsync(int authorId, int id, Book book)
        {
            var bookEntity = _books.Where(b => b.AuthorId == authorId && b.Id == id).FirstOrDefault();
            if (bookEntity != null)
            {
                bookEntity.Title = book.Title;
                bookEntity.PublishedYear = book.PublishedYear;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int authorId, int id)
        {
            var bookEntity = _books.FirstOrDefault(b => b.AuthorId == authorId && b.Id == id);
            if (bookEntity != null)
            {
                _books.Remove(bookEntity);
            }
            return Task.CompletedTask;
        }
    }
}