//using Core.Entities.Model;
//using Core.Interfaces;

//namespace DAL.InMemoryRepository
//{
//    public class InMemoryAuthorRepository : IAuthorRepository
//    {
//        private readonly List<Author> _authors;

//        public InMemoryAuthorRepository()
//        {
//            _authors = new List<Author>
//            {
//                new() { Id = 1, Name = "Leo Tolstoy", DateOfBirth = new DateTime(1828, 9, 9), Books = new List<Book>() },
//                new() { Id = 2, Name = "Fyodor Dostoevsky", DateOfBirth = new DateTime(1821, 11, 11), Books = new List<Book>() },
//                new() { Id = 3, Name = "Jane Austen", DateOfBirth = new DateTime(1775, 12, 16), Books = new List<Book>() }
//            };
//        }

//        public Task<IEnumerable<Author>> GetAllAsync() => Task.FromResult(_authors.AsEnumerable());

//        public Task<Author?> GetByIdAsync(int id)
//        {
//            var author = _authors.FirstOrDefault(a => a.Id == id);
//            return Task.FromResult(author);
//        }

//        public Task<Author> CreateAsync(Author author)
//        {
//            _authors.Add(author);
//            return Task.FromResult(author);
//        }

//        public Task UpdateAsync(int id, Author updatedAuthor)
//        {
//            var authorEntity = _authors.FirstOrDefault(a => a.Id == id);
//            if (authorEntity != null)
//            {
//                authorEntity.Name = updatedAuthor.Name;
//                authorEntity.DateOfBirth = updatedAuthor.DateOfBirth;
//                authorEntity.Books = updatedAuthor.Books;
//            }
//            return Task.CompletedTask;
//        }
//        public Task DeleteAsync(int id)
//        {
//            var authorEntity = _authors.FirstOrDefault(a => a.Id == id);
//            if (authorEntity != null)
//                _authors.Remove(authorEntity);

//            return Task.CompletedTask;
//        }
//    }
//}
