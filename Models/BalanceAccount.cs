namespace FinancialSettlementService.Models
{
    using FinancialSettlementService.Validations;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Банковский счёт.
    /// </summary>
    public class BalanceAccount: BaseEntity
    {
        /// <summary>
        /// Баланс.
        /// </summary>
        [Required(ErrorMessage = "Баланс не может быть пустым.")]
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
