using FinancialSettlementService.Validations;
using System.ComponentModel.DataAnnotations;

namespace FinancialSettlementService.Models
{
    /// <summary>
    /// Банковский счёт.
    /// </summary>
    public class BalanceAccount: BaseEntity
    {
        /// <summary>
        /// Баланс.
        /// </summary>
        [Required(ErrorMessage = "Баланс не может быть пустым.")]
        [VerifyFormat(TypeName:"decimal")]
        [NoNegativeValue]
        public decimal Balance { get; set; }

        /// <summary>
        /// Id клиента.
        /// </summary>
        [Required(ErrorMessage = "Идентификатор клиента не может быть пустым.")]
        public Guid ClientId { get; set; }

        /// <summary>
        /// Клиент банка.
        /// </summary>
        public Client Client { get; set; }
    }
}
