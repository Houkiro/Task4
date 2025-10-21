using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities.Model;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorResponseDto>> GetAllAsync()
        {
            var authors = await _repository.Author.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
        }

        public async Task<AuthorResponseDto> GetByIdAsync(int id)
        {
            var author = await _repository.Author.GetByIdAsync(id);
            if (author is null)
                throw new AuthorNotFoundException(id);

            return _mapper.Map<AuthorResponseDto>(author);
        }

        public async Task<AuthorResponseDto> CreateAsync(CreateAuthorModelDto AuthorResponseDto)
        {
            var author = _mapper.Map<Author>(AuthorResponseDto);
            _repository.Author.Create(author);

            await _repository.SaveAsync();

            return _mapper.Map<AuthorResponseDto>(author);
        }

        public async Task UpdateAsync(int id, UpdateAuthorModelDto AuthorResponseDto)
        {
            var existingAuthor = await _repository.Author.GetByIdAsync(id);
            if (existingAuthor is null)
                throw new AuthorNotFoundException(id);
            _mapper.Map(AuthorResponseDto, existingAuthor);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var authorEntity = await _repository.Author.GetByIdAsync(id);
            if (authorEntity is null)
                throw new AuthorNotFoundException(id);

            _repository.Author.Delete(authorEntity);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync()
        {
            var authors = await _repository.Author.GetAllWithBooksAsync();

            return _mapper.Map<IEnumerable<AuthorWithBookCountDto>>(authors);
        }


        public async Task<IEnumerable<AuthorResponseDto>> GetAuthorsWithBooksAfterYearAsync(int year)
        {
            var authors = await _repository.Author.GetAuthorsWithBooksAfterYearAsync(year);
            return _mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
        }

        public async Task<IEnumerable<AuthorResponseDto>> FindAuthorsByNameAsync(string namePart)
        {
            var authors = await _repository.Author.FindAuthorsByNameAsync(namePart);
            return _mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
        }
    }
}