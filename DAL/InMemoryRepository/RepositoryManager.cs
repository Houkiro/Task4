using Core.Interfaces;

namespace DAL.InMemoryRepository
{
    public class RepositoryManager : IRepositoryManager
    {
        private Lazy<IAuthorRepository> _authorRepository;
        private Lazy<IBookRepository> _bookRepository;

        public RepositoryManager()
        {
            _authorRepository = new Lazy<IAuthorRepository>(() => new InMemoryAuthorRepository());
            _bookRepository = new Lazy<IBookRepository>(() => new InMemoryBookRepository());
        }
        public IAuthorRepository Author => _authorRepository.Value;
        public IBookRepository Book => _bookRepository.Value;
    }
}
