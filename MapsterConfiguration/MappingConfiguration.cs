namespace FinancialSettlementService.MapsterConfiguration
{
    using FinancialSettlementService.Dtos;
    using FinancialSettlementService.Helpers;
    using FinancialSettlementService.Models;
    using Mapster;
    using System.Globalization;

    /// <summary>
    /// Настройки маппинга моделей.
    /// </summary>
    public class MappingConfiguration : IRegister
    {
        private readonly string _dateTimeFormat = ValidationTypeConstants.DateTimeFormat;
        public MappingConfiguration() { }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ClientDto, Client>()
                .Map(dest => dest.BirthDay, source => ConvertStringToDateTime(source.BirthDay));
            config.NewConfig<Client, ClientInformationDto>()
                .Map(dest => dest.BirthDay, 
                source => ConvertDateTimeToString(source.BirthDay, _dateTimeFormat));
        }

        /// <summary>
        /// Преобразует строку в нужный формат DateTime.
        /// </summary>
        /// <param name="dateTimeString"> Строка для преобразования. </param>
        /// <returns> DateTime в заданном формате. </returns>
        private DateTime ConvertStringToDateTime(string dateTimeString) 
        {
            var dateWithoutKind = DateTime.ParseExact(dateTimeString, _dateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None);

            return DateTime.SpecifyKind(dateWithoutKind, DateTimeKind.Utc);
        }

        /// <summary>
        /// Преобразует дату в строку.
        /// </summary>
        /// <param name="dateTimeString"> Строка для преобразования. </param>
        /// <returns> Строка в заданном формате. </returns>
        private static string ConvertDateTimeToString(DateTime dateTimeString, string _dateTimeFormat) 
            => dateTimeString.ToString(_dateTimeFormat);
    }
}