using FinancialSettlementService.ValidationAttributes;
using FinancialSettlementService.Validations;
using System.ComponentModel.DataAnnotations;

namespace FinancialSettlementService.Dtos
{
    /// <summary>
    /// Dto клиента.
    /// </summary>
    public class ClientDto: BaseEntityDto
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        [VerifyFormat(TypeName: "System.String")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [VerifyFormat(TypeName: "System.String")]
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения.
        /// </summary>
        [Required(ErrorMessage = "Поле 'Дата рождения' обязательно для заполнения.")]
        [DateTimeFormat(DateFormat:"dd.MM.yyyy")]
        public string BirthDay { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [VerifyFormat(TypeName: "System.String")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Баланс.
        /// </summary>
        [Required(ErrorMessage = "Баланс не может быть пустым.")]
        [VerifyFormat(TypeName: "System.Decimal")]
        [NoNegativeValue]
        public decimal Balance { get; set; }
    }
}
