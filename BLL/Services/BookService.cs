using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities.Model;
using DAL.Interfaces;

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

        public async Task<IEnumerable<BookResponseDto>> GetAllBooksForAuthorAsync(int authorId)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var books = await _repository.Book.GetAllBooksByAuthorIdAsync(authorId);
            return _mapper.Map<IEnumerable<BookResponseDto>>(books);
        }

        public async Task<BookResponseDto> GetBooksForAuthorByIdAsync(int authorId, int id)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if(author is null)
                throw new AuthorNotFoundException(authorId);
            var book = await _repository.Book.GetBookByAuthorIdAsync(authorId, id);
            if (book is null)
                throw new BookNotFoundException(id);
            return _mapper.Map<BookResponseDto>(book);
        }

        public async Task<BookResponseDto> CreateBookForAuthor(int authorId, CreateBookModelDto BookResponseDto)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);
            var book = _mapper.Map<Book>(BookResponseDto);

            _repository.Book.CreateAsync(author.Id, book);
            await _repository.SaveAsync();
            return _mapper.Map<BookResponseDto>(book);
        }
        public async Task UpdateBookForAuthorAsync(int authorId, int id, UpdateBookModelDto BookResponseDto)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);
            var bookEntity = await _repository.Book.GetBookByAuthorIdAsync(author.Id, id);
            if (bookEntity is null)
                throw new BookNotFoundException(id);
            _mapper.Map(BookResponseDto, bookEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteBookForAuthorAsync(int authorId, int id)
        {
            var author = await _repository.Author.GetByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var book = await _repository.Book.GetBookByAuthorIdAsync(author.Id, id);
            if (book is null)
                throw new BookNotFoundException(id);
            
            _repository.Book.DeleteAsync(book);
            await _repository.SaveAsync();
        }
    }
}