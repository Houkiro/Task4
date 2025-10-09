using BLL.Interfaces;
using Core.Entities.Model;
using Core.Interfaces;
using Shared.DTO;

namespace BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        public BookService(IBookRepository bookRepository, IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
        }
        public async Task<IEnumerable<BookDto>> GetAllBooksForAuthorAsync(int authorId)
        {
            var author = await _authorService.GetByIdAsync(authorId);
            if (author is null)
                throw new ArgumentException($"Author with ID {authorId} not found");

            var books = await _bookRepository.GetAllBooksByAuthorIdAsync(authorId);

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                PublishedYear = b.PublishedYear,
                AuthorId = b.AuthorId
            });
        }

        public async Task<BookDto> GetBooksForAuthorByIdAsync(int authorId, int id)
        {
            var author = await _authorService.GetByIdAsync(authorId);
            if(author is null)
                throw new ArgumentException($"Author with ID {authorId} not found");
            var book = await _bookRepository.GetBookByAuthorIdAsync(authorId, id);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                PublishedYear = book.PublishedYear,
                AuthorId = book.AuthorId
            };
        }

        public async Task<BookDto> CreateBookForAuthor(int authorId, BookDto bookDto)
        {
            var author = await _authorService.GetByIdAsync(authorId);
            if (author is null)
                throw new ArgumentException($"Author with ID {authorId} not found");
            var book = new Book
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = author.Id
            };
            var created = await _bookRepository.CreateAsync(author.Id, book);

            return new BookDto
            {
                Id = created.Id,
                Title = created.Title,
                PublishedYear = created.PublishedYear,
                AuthorId = created.AuthorId
            };
        }
        public async Task<BookDto> UpdateBookForAuthorAsync(int authorId, int id, BookDto bookDto)
        {
            var author = await _authorService.GetByIdAsync(authorId);
            if (author is null)
                throw new ArgumentException($"Author with ID {authorId} not found");
            var existingBook = await _bookRepository.GetBookByAuthorIdAsync(author.Id, id);
            if (existingBook is null)
                throw new ArgumentException($"Book with ID {id} not found");
            existingBook.Title = bookDto.Title;
            existingBook.PublishedYear = bookDto.PublishedYear;
            existingBook.AuthorId = author.Id;

            await _bookRepository.UpdateAsync(author.Id, id, existingBook);

            return new BookDto
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                PublishedYear = existingBook.PublishedYear,
                AuthorId = existingBook.AuthorId
            };
        }

        public async Task<bool> DeleteBookForAuthor(int authorId, int id)
        {
            var author = await _authorService.GetByIdAsync(authorId);
            if (author is null)
                throw new ArgumentException($"Author with ID {authorId} not found");

            var book = await _bookRepository.GetBookByAuthorIdAsync(author.Id, id);
            if (book is null)
                throw new ArgumentException($"Book with ID {id} not found");
            await _bookRepository.DeleteAsync(author.Id, id);
            return true;
        }
    }
}