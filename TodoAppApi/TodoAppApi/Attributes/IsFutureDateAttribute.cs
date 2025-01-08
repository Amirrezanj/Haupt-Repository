using System.ComponentModel.DataAnnotations;

namespace TodoAppApi.Attributes
{
    public class IsFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.UtcNow;
            }
            return false;
        }
    }
}
