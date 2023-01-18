using System.ComponentModel.DataAnnotations;

namespace BookWebStore.BLL.Attributes
{
    public class ValidateDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid
            (object obj, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(obj);

            return (date <= DateTime.UtcNow && date >= DateTime.UtcNow.AddYears(-1))
                ? ValidationResult.Success
                : new ValidationResult("Invalid date range");
        }

        //public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        //{
        //    DateTime d = Convert.ToDateTime(value);
        //    return d >= DateTime.UtcNow; //Dates Greater than or equal to today are valid (true)
        //}
    }
}
