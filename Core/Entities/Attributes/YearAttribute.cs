using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Attributes.DTO
{
    public class YearAttribute : ValidationAttribute
    {
        public YearAttribute()
        {
            ErrorMessage = "Год публикации не может быть в будущем";
        }

        public override bool IsValid(object? value)
        {
            if (value is int year)
            {
                return year <= DateTime.Today.Year && year > 0;
            }

            return false;
        }
    }
}