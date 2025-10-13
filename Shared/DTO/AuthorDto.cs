using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test4.Attributes;

namespace Shared.DTO
{
    public class AuthorDto
    {
        [Column("AuthorId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя это обязательное поле")]
        [MaxLength(60, ErrorMessage = "Максимальная длинна имени 60 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Дата рождения обязательное поле")]
        [Date]
        public DateTime DateOfBirth { get; set; }
    }
}