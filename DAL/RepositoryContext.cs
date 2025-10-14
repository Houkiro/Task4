using Core.Entities.Model;
using DAL.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }

        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
    }
}