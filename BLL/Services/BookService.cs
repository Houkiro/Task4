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

        public async Task<IEnumerable<BookDto>> GetAllBooksForAuthorAsync(int authorId, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var books = await _repository.Book.GetAllBooksByAuthorIdAsync(authorId, trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return booksDto;
        }

        public async Task<BookDto> GetBooksForAuthorByIdAsync(int authorId, int id, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            if(author is null)
                throw new AuthorNotFoundException(authorId);
            var book = await _repository.Book.GetBookByAuthorIdAsync(authorId, id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);
            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task<BookDto> CreateBookForAuthor(int authorId, BookDtoWithoutId bookDto, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);
            var book = _mapper.Map<Book>(bookDto);

            _repository.Book.CreateAsync(author.Id, book);
            await _repository.SaveAsync();
            var createdDto = _mapper.Map<BookDto>(book);

            return createdDto;
        }
        public async Task UpdateBookForAuthorAsync(int authorId, int id, BookDtoWithoutId bookDto, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);
            var bookEntity = await _repository.Book.GetBookByAuthorIdAsync(author.Id, id, trackChanges);
            if (bookEntity is null)
                throw new BookNotFoundException(id);
            _mapper.Map(bookDto, bookEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteBookForAuthorAsync(int authorId, int id, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var book = await _repository.Book.GetBookByAuthorIdAsync(author.Id, id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);
            
            _repository.Book.DeleteAsync(book);
            await _repository.SaveAsync();
        }
    }
}