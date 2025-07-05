using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricCompanyAPI.Domain
{
    public interface IHistoricDataRepository
    {
        Task<IEnumerable<HistoricDataResponse>> GetHistoricDataAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<HistoricDataResponse>> GetTopPowerLossesAsync(DateTime startDate, DateTime endDate);


    }
}
