using AutoMapper;
using BLL.Interfaces;
using Core.Entities.Model;
using Core.Exceptions;
using Core.Interfaces;
using Shared.DTO;

namespace BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BookService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> GetAllBooksForAuthorAsync(int authorId)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var books = await _repository.Book.GetAllBooksByAuthorIdAsync(authorId);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return booksDto;
        }

        public async Task<BookDto> GetBooksForAuthorByIdAsync(int authorId, int id)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if(author is null)
                throw new AuthorNotFoundException(authorId);
            var book = await _repository.Book.GetBookByAuthorIdAsync(authorId, id);
            if (book is null)
                throw new BookNotFoundException(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<BookDto> CreateBookForAuthor(int authorId, BookDto bookDto)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);
            var book = _mapper.Map<Book>(bookDto);

            var created = await _repository.Book.CreateAsync(author.Id, book);
            var createdDto = _mapper.Map<BookDto>(created);
            return createdDto;
        }
        public async Task<BookDto> UpdateBookForAuthorAsync(int authorId, int id, BookDto bookDto)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);
            var existingBook = await _repository.Book.GetBookByAuthorIdAsync(author.Id, id);
            if (existingBook is null)
                throw new BookNotFoundException(id);
            existingBook.Title = bookDto.Title;
            existingBook.PublishedYear = bookDto.PublishedYear;
            existingBook.AuthorId = author.Id;

            await _repository.Book.UpdateAsync(author.Id, id, existingBook);
            return _mapper.Map<BookDto>(existingBook);
        }

        public async Task<bool> DeleteBookForAuthorAsync(int authorId, int id)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var book = await _repository.Book.GetBookByAuthorIdAsync(author.Id, id);
            if (book is null)
                throw new BookNotFoundException(id);
            await _repository.Book.DeleteAsync(author.Id, id);
            return true;
        }
    }
}