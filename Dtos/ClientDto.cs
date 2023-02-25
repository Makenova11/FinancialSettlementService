namespace FinancialSettlementService.Dtos
{
    using FinancialSettlementService.Helpers;
    using FinancialSettlementService.ValidationAttributes;
    using FinancialSettlementService.Validations;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Dto клиента.
    /// </summary>
    public class ClientDto
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        [VerifyFormat(TypeName: ValidationTypeConstants.SystemString)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [VerifyFormat(TypeName: ValidationTypeConstants.SystemString)]
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения.
        /// </summary>
        [Required(ErrorMessage = "Поле 'Дата рождения' обязательно для заполнения.")]
        [DateTimeFormat(DateFormat: ValidationTypeConstants.DateTimeFormat)]
        public string BirthDay { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [VerifyFormat(TypeName: ValidationTypeConstants.SystemString)]
        public string? Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// Баланс.
        /// </summary>
        [Required(ErrorMessage = "Баланс не может быть пустым.")]
        [VerifyFormat(TypeName: ValidationTypeConstants.SystemDecimal)]
        [NoNegativeValue]
        public decimal Balance { get; set; }
    }
}
