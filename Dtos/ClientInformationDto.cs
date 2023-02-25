namespace FinancialSettlementService.Dtos
{
    /// <summary>
    /// Dto информации о клиенте.
    /// </summary>
    public class ClientInformationDto : BaseEntityDto
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения.
        /// </summary>
        public string BirthDay { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; } = string.Empty;
    }
}
