using DAL.Interfaces;

namespace DAL.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private Lazy<IAuthorRepository> _authorRepository;
        private Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
        }

        public IAuthorRepository Author => _authorRepository.Value;

        public IBookRepository Book => _bookRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}