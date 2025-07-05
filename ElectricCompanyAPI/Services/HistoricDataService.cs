using ElectricCompanyAPI.Domain;

namespace ElectricCompanyAPI
{
    public class HistoricDataService
    {
        private readonly IHistoricDataRepository _repository;

        public HistoricDataService(IHistoricDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dictionary<string, List<HistoricDataResponse>>> GetHistoricDataBySectionAsync(DateTime startDate, DateTime endDate)
        {
            // Obtención de datos desde el repositorio
            var data = await _repository.GetHistoricDataAsync(startDate, endDate);

            // Agrupar los datos por "Section" (Tramo)
            var groupedBySection = data
                .GroupBy(x => x.Section) // Agrupamos por "Section"
                .ToDictionary(group => group.Key, group => group.Select(x => new HistoricDataResponse
                {
                    Date = x.Date,
                    Section=x.Section,
                    CustomerType = x.CustomerType,
                    Consumption = x.Consumption,
                    LossPercentage = x.LossPercentage,
                    CostPerWh = x.CostPerWh
                }).ToList());

            return groupedBySection;
        }

        public async Task<Dictionary<string, List<HistoricDataResponse>>> GetHistoricDataByCustomerTypeAsync(DateTime startDate, DateTime endDate)
        {
            // Obtención de datos desde el repositorio
            var data = await _repository.GetHistoricDataAsync(startDate, endDate);

            // Agrupar los datos por "Section" (Tramo)
            var groupedBySection = data
                .GroupBy(x => x.CustomerType) // Agrupamos por "Section"
                .ToDictionary(group => group.Key, group => group.Select(x => new HistoricDataResponse
                {
                    Date = x.Date,
                    Section = x.Section,
                    CustomerType = x.CustomerType,
                    Consumption = x.Consumption,
                    LossPercentage = x.LossPercentage,
                    CostPerWh = x.CostPerWh
                }).ToList());

            return groupedBySection;
        }

        public async Task<IEnumerable<HistoricDataResponse>> GetTopPowerLossesAsync(DateTime startDate, DateTime endDate)
        {
            // Obtención de datos desde el repositorio
            return await _repository.GetTopPowerLossesAsync(startDate, endDate);

           
        }
    }
}
