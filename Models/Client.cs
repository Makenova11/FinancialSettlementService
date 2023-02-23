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
        [Required]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения.
        /// </summary>
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты.")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Счет пользователя.
        /// </summary>
        public BalanceAccount BalanceAccount { get; set; }
    }
}
