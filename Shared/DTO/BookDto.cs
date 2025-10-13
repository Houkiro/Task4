using Core.Entities.Model;
using Shared.DTO.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test4.Attributes;

namespace Shared.DTO
{
    public class BookDto
    {
        [Column("BookId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательное поле")]
        [MaxLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Title { get; set; }
        [Year]
        public int PublishedYear { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
    }
}