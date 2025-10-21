using DAL.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder) 
        {
            builder.HasData
                (
                    new Author 
                    { 
                        Id = 1, 
                        Name = "Leo Tolstoy", 
                        DateOfBirth = new DateTime(1828, 9, 9)
                    },
                    new Author 
                    {
                        Id = 2, 
                        Name = "Fyodor Dostoevsky", 
                        DateOfBirth = new DateTime(1821, 11, 11)
                    },
                    new Author
                    {
                        Id = 3,
                        Name = "Jane Austen",
                        DateOfBirth = new DateTime(1775, 12, 16)
                    }
                );
        }
    }
}