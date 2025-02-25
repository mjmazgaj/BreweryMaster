using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.SharedModule.Validators
{
    public class DateTimeRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || (DateTime)value == DateTime.MinValue)
            {
                return new ValidationResult($"{validationContext.MemberName} is required.");
            }

            return ValidationResult.Success;
        }
    }
}
