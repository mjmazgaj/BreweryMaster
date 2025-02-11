using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.SharedModule.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class MinIntValidationAttribute : ValidationAttribute
    {
        public MinIntValidationAttribute(int min = 1, bool isNullAllowed = false)
        {
            MinInt = min;
            IsNullAllowed = isNullAllowed;
        }

        private int MinInt { get; }
        private bool IsNullAllowed { get; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return IsNullAllowed
                    ? ValidationResult.Success
                    : new ValidationResult($"The field {validationContext.MemberName} is required.");
            }

            if (value is int intValue)
            {
                if (intValue < MinInt)
                {
                    return new ValidationResult($"The field {validationContext.MemberName} must be at least {MinInt}.");
                }
                return ValidationResult.Success;
            }

            return new ValidationResult($"The field {validationContext.MemberName} must be an integer.");
        }
    }
}
