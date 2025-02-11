using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace BreweryMaster.API.SharedModule.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class MinIntCollectionValidationAttribute : ValidationAttribute
    {
        public MinIntCollectionValidationAttribute(int min = 1, bool isNullAllowed = false)
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
                if (IsNullAllowed)
                    return ValidationResult.Success;
                else
                    return new ValidationResult($"The field {validationContext.MemberName} is required.");
            }

            if (value is IEnumerable<int> collection)
            {
                var invalidValues = collection.Where(x => x < MinInt).ToList();
                if (invalidValues.Any())
                {
                    return new ValidationResult($"The field {validationContext.MemberName} contains invalid values: {string.Join(", ", invalidValues)}. All values must be at least {MinInt}.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult($"The field {validationContext.MemberName} must be a collection of integers.");
        }
    }
}
