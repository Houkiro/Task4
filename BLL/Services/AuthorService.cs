using AutoMapper;
using BLL.Interfaces;
using Core.Entities.Model;
using Core.Exceptions;
using Core.Interfaces;
using Shared.DTO;

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

        public async Task<IEnumerable<AuthorDto>> GetAllAsync(bool trackChanges)
        {
            var authors = await _repository.Author.GetAllAsync(trackChanges);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }

        public async Task<AuthorDto> GetByIdAsync(int id, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(id, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(id);

            var authorDto = _mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<AuthorDto> CreateAsync(AuthorDtoWithoutId authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _repository.Author.CreateAsync(author);

            await _repository.SaveAsync();
            var createdDto = _mapper.Map<AuthorDto>(author);

            return createdDto;
        }

        public async Task UpdateAsync(int id, AuthorDtoWithoutId authorDto, bool trackChanges)
        {
            var existingAuthor = await _repository.Author.GetByIdAsync(id, trackChanges);
            if (existingAuthor is null)
                throw new AuthorNotFoundException(id);
            _mapper.Map(authorDto, existingAuthor);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id, bool trackChanges)
        {
            var authorEntity = await _repository.Author.GetByIdAsync(id, trackChanges);
            if (authorEntity is null)
                throw new AuthorNotFoundException(id);

            _repository.Author.DeleteAsync(authorEntity);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync(bool trackChanges)
        {
            var authors = await _repository.Author.GetAllWithBooksAsync(trackChanges);

            var result = authors.Select(a => new AuthorWithBookCountDto
            {
                AuthorId = a.Id,
                Name = a.Name,
                BookCount = a.Books?.Count ?? 0
            });

            return result;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsWithBooksAfterYearAsync(int year, bool trackChanges)
        {
            var authors = await _repository.Author.GetAuthorsWithBooksAfterYearAsync(year, trackChanges);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }

        public async Task<IEnumerable<AuthorDto>> FindAuthorsByNameAsync(string namePart, bool trackChanges)
        {
            var authors = await _repository.Author.FindAuthorsByNameAsync(namePart, trackChanges);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }
    }
}