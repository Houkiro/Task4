using BLL.Interfaces;
using Core.Entities.Model;
using Core.Interfaces;
using Shared.DTO;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth
            });
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return null;

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth
            };
        }

        public async Task<AuthorDto> CreateAsync(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                DateOfBirth = authorDto.DateOfBirth,
                Books = new List<Book>()
            };

            var created = await _authorRepository.CreateAsync(author);

            return new AuthorDto
            {
                Id = created.Id,
                Name = created.Name,
                DateOfBirth = created.DateOfBirth
            };
        }

        public async Task<AuthorDto?> UpdateAsync(int id, AuthorDto authorDto)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(id);
            if (existingAuthor == null)
                  throw new ArgumentException($"Author with ID {id} not found");

            existingAuthor.Name = authorDto.Name;
            existingAuthor.DateOfBirth = authorDto.DateOfBirth;

            await _authorRepository.UpdateAsync(id, existingAuthor);

            return new AuthorDto
            {
                Id = existingAuthor.Id,
                Name = existingAuthor.Name,
                DateOfBirth = existingAuthor.DateOfBirth
            };
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author is null)
                throw new ArgumentException($"Author with ID {id} not found");

            await _authorRepository.DeleteAsync(id);
            return true;
        }

    }
}