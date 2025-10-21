namespace DAL.Interfaces
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }

        IBookRepository Book { get; }

        Task SaveAsync();
    }
}