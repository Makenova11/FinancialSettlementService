using FinancialSettlementService.Validations;
using System.ComponentModel.DataAnnotations;

namespace FinancialSettlementService.Models
{
    /// <summary>
    /// Клиент банка.
    /// </summary>
    public class Client: BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        [VerifyFormat(TypeName: "string")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [VerifyFormat(TypeName: "string")]
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения.
        /// </summary>
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Некорректный формат даты.")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [VerifyFormat(TypeName: "string")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Счет пользователя.
        /// </summary>
        public BalanceAccount BalanceAccount { get; set; }
    }
}
