namespace FinancialSettlementService.Helpers
{
    /// <summary>
    /// Константы для валидирования данных.
    /// </summary>
    public static class ValidationTypeConstants
    {
        /// <summary>
        /// Константа для форматат даты.
        /// </summary>
        public const string DateTimeFormat = "dd.MM.yyyy";

        /// <summary>
        /// Константа, описывающая тип string.
        /// </summary>
        public const string SystemString = "System.String";

        /// <summary>
        /// Константа, описывающая тип decimal.
        /// </summary>
        public const string SystemDecimal = "System.Decimal";

        /// <summary>
        /// Константа, описывающая ограничение негативного баланса.
        /// </summary>
        public const string NoNegativeBalanceConstraint = "NoNegativeBalanceConstraint";
    }
}
