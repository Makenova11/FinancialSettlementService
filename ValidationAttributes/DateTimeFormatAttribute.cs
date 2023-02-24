namespace FinancialSettlementService.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    /// <summary>
    /// Атрибут валидации даты.
    /// </summary>
    public class DateTimeFormatAttribute : ValidationAttribute
    {
        private readonly string _dateTimeFormat;
        public DateTimeFormatAttribute(string DateFormat)
        {
            _dateTimeFormat = DateFormat;
            ErrorMessage = $"Введённое значение не соответствует типу {_dateTimeFormat}." +
                $"\n Минимальный год - 1900." +
                $"\n Минимальный возраст клиента - 14 лет.";
        }

        public override bool IsValid(object value)
        {
            var isDate = DateTime.TryParseExact((string)value, _dateTimeFormat,
                CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date);
            var hasCorrectValue = date.Year >= 1900 && DateTime.Today.Year - date.Year >= 14;

            return isDate && hasCorrectValue;
        }
    }
}
