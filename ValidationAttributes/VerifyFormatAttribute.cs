using System.ComponentModel.DataAnnotations;

namespace FinancialSettlementService.Validations
{
    /// <summary>
    /// Атрибут проверки введёного значения на заданный тип.
    /// </summary>
    public class VerifyFormatAttribute : ValidationAttribute
    {
        /// <summary>
        /// Тип значения.
        /// </summary>
        private readonly string _TypeName;
        public VerifyFormatAttribute(string TypeName)
        {
            _TypeName = TypeName;
            ErrorMessage = $"Введённое значение не соответствует типу '{TypeName}'.";
        }

        public override bool IsValid(object value)
        {
            var TypeObject = Type.GetType(_TypeName).FullName;
            var ValueType = value.GetType().FullName;

            return TypeObject == ValueType;
        }
    }
}
