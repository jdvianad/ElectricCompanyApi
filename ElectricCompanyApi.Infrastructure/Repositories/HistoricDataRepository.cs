using ElectricCompanyAPI.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace ElectricCompanyApi.Infrastructure
{
    public class HistoricDataRepository : IHistoricDataRepository
    {
        private readonly string _connectionString;

        public HistoricDataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<HistoricDataResponse>> GetHistoricDataAsync(DateTime startDate, DateTime endDate)
        {
            var query = @"
            SELECT 
                ec.Section,
                ec.CustomerType,
                ec.Consumption,
                pl.LossPercentage,
                pc.CostPerWh,
                ec.Date
            FROM ElectricConsumption ec
            JOIN PowerLoss pl ON ec.Section = pl.Section AND ec.CustomerType = pl.CustomerType AND ec.Date = pl.Date
            JOIN PowerCostPerWh pc ON ec.Section = pc.Section AND ec.CustomerType = pc.CustomerType AND ec.Date = pc.Date
            WHERE ec.Date BETWEEN @StartDate AND @EndDate";

            using (var connection = new SqlConnection(_connectionString))
            {
                var data = await connection.QueryAsync<HistoricDataResponse>(query, new { StartDate = startDate, EndDate = endDate });
                return data;
            }
        }

        public async Task<IEnumerable<HistoricDataResponse>> GetTopPowerLossesAsync(DateTime startDate, DateTime endDate)
        {
            var query = @"
            SELECT TOP 20
                ec.Section,
                ec.CustomerType,
                ec.Consumption,
                pl.LossPercentage,
                pc.CostPerWh,
                ec.Date
            FROM ElectricConsumption ec
            JOIN PowerLoss pl ON ec.Section = pl.Section AND ec.CustomerType = pl.CustomerType AND ec.Date = pl.Date
            JOIN PowerCostPerWh pc ON ec.Section = pc.Section AND ec.CustomerType = pc.CustomerType AND ec.Date = pc.Date
            WHERE ec.Date BETWEEN @StartDate AND @EndDate
            ORDER BY pl.LossPercentage DESC";

            using (var connection = new SqlConnection(_connectionString))
            {
                var data = await connection.QueryAsync<HistoricDataResponse>(query, new { StartDate = startDate, EndDate = endDate });
                return data;
            }
        }

    }

}

