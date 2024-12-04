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

        public override bool IsValid(object? value)
        {
            return value == null && IsNullAllowed
                    || value != null && (int)value >= MinInt;
        }
    }
}
