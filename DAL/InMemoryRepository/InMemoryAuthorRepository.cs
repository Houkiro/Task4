using Core.Entities.Model;
using Core.Interfaces;

namespace DAL.InMemoryRepository
{
    public class InMemoryAuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors;
        public InMemoryAuthorRepository()
        {
            _authors = new List<Author>
    {
        new Author
        {
            Id = 1,
            Name = "Leo Tolstoy",
            DateOfBirth = new DateTime(1828, 9, 9),
            Books = new List<Book>()
        },
        new Author
        {
            Id = 2,
            Name = "Fyodor Dostoevsky",
            DateOfBirth = new DateTime(1821, 11, 11),
            Books = new List<Book>()
        },
        new Author
        {
            Id = 3,
            Name = "Jane Austen",
            DateOfBirth = new DateTime(1775, 12, 16),
            Books = new List<Book>()
        },
        new Author
        {
            Id = 4,
            Name = "Ernest Hemingway",
            DateOfBirth = new DateTime(1899, 7, 21),
            Books = new List<Book>()
        },
        new Author
        {
            Id = 5,
            Name = "George Orwell",
            DateOfBirth = new DateTime(1903, 6, 25),
            Books = new List<Book>()
        }
    };
        }
        private int _nextId = 1;
        public Task<IEnumerable<Author>> GetAllAsync() => Task.FromResult(_authors.AsEnumerable());

        public Task<Author?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> CreateAsync(Author author)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}