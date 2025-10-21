using DAL.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
                new Book 
                { 
                    Id = 1, 
                    Title = "War and Peace", 
                    PublishedYear = 1869, 
                    AuthorId = 1 
                },
                new Book 
                {
                    Id = 2, 
                    Title = "Anna Karenina", 
                    PublishedYear = 1877, 
                    AuthorId = 1 
                },
                new Book 
                { 
                    Id = 3, 
                    Title = "The Death of Ivan Ilyich", 
                    PublishedYear = 1886, 
                    AuthorId = 1 
                },

                new Book 
                {
                    Id = 4, 
                    Title = "Crime and Punishment",
                    PublishedYear = 1866,
                    AuthorId = 2 
                },
                new Book 
                {
                    Id = 5, 
                    Title = "The Brothers Karamazov", 
                    PublishedYear = 1880, 
                    AuthorId = 2 
                },
                new Book 
                {
                    Id = 6, 
                    Title = "The Idiot", 
                    PublishedYear = 1869, 
                    AuthorId = 2 
                },

                new Book 
                {
                    Id = 7, 
                    Title = "Pride and Prejudice", 
                    PublishedYear = 1813, 
                    AuthorId = 3 
                },
                new Book 
                {
                    Id = 8,
                    Title = "Sense and Sensibility", 
                    PublishedYear = 1811, 
                    AuthorId = 3 
                },
                new Book 
                {
                    Id = 9, 
                    Title = "Emma", 
                    PublishedYear = 1815, 
                    AuthorId = 3 
                }
            );
        }   
    }
}