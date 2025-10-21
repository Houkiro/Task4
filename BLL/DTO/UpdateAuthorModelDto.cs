using BLL.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class UpdateAuthorModelDto : AuthorDto
    {
        [Required(ErrorMessage = "Имя это обязательное поле")]
        [MaxLength(60, ErrorMessage = "Максимальная длинна имени 60 символов")]
        public new string Name { get => base.Name; set => base.Name = value; }

        [Required(ErrorMessage = "Дата рождения обязательное поле")]
        [Date]
        public new DateTime DateOfBirth { get => base.DateOfBirth; set => base.DateOfBirth = value; }
    }
}
