using System.ComponentModel.DataAnnotations;

namespace FinancialSettlementService.Validations
{
    /// <summary>
    /// Атрибут проверки на отрицательные числа.
    /// </summary>
    public class NoNegativeValueAttribute : ValidationAttribute
    {
        public NoNegativeValueAttribute()
        {
            ErrorMessage = "Баланс не может быть отрицательным.";
        }

        public override bool IsValid(object value)
        {
            return (decimal)value >= 0;
        }
    }
}
