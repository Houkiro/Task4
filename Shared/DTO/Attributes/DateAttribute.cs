using System.ComponentModel.DataAnnotations;

namespace Test4.Attributes
{
    public class DateAttribute : ValidationAttribute
    {
        public DateAttribute() 
        {
            ErrorMessage = "Дата не может быть в будущем";
        }
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Today;
            }
            return false;
        }
    }
}
