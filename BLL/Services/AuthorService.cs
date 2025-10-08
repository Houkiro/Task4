using BLL.Interfaces;
using Core.Interfaces;
using Shared.DTO;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var result = authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth
            });
            return result;
        }

        public Task<AuthorDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<AuthorDto> CreateAsync(AuthorDto author)
        {
            throw new NotImplementedException();
        }
        public Task<AuthorDto> UpdateAsync(int id, AuthorDto author)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}