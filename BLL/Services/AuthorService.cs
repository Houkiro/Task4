using AutoMapper;
using BLL.Interfaces;
using Core.Entities.Model;
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

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _repository.Author.GetAllAsync();
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return authorsDto;
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _repository.Author.GetByIdAsync(id);
            if (author == null) return null;
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public async Task<AuthorDto> CreateAsync(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            author.Books = new List<Book>();

            var created = await _repository.Author.CreateAsync(author);
            var createdDto = _mapper.Map<AuthorDto>(created);
            return createdDto;
        }

        public async Task<AuthorDto?> UpdateAsync(int id, AuthorDto authorDto)
        {
            var existingAuthor = await _repository.Author.GetByIdAsync(id);
            if (existingAuthor == null)
                  throw new ArgumentException($"Author with ID {id} not found");

            existingAuthor.Name = authorDto.Name;
            existingAuthor.DateOfBirth = authorDto.DateOfBirth;

            await _repository.Author.UpdateAsync(id, existingAuthor);

            return _mapper.Map<AuthorDto>(existingAuthor);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _repository.Author.GetByIdAsync(id);
            if (author is null)
                throw new ArgumentException($"Author with ID {id} not found");

            await _repository.Author.DeleteAsync(id);
            return true;
        }

    }
}