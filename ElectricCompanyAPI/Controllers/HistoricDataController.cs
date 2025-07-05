using Microsoft.AspNetCore.Mvc;

namespace ElectricCompanyAPI.Controllers
{
    

    namespace ElectricCompanyAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class HistoricDatabySectionController : ControllerBase
        {
            private readonly HistoricDataService _historicDataService;
            public HistoricDatabySectionController(HistoricDataService historicDataService)
            {
                _historicDataService = historicDataService;
            }

            [HttpGet]
            public async Task<IActionResult> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
            {
                try
                {
                    var result = await _historicDataService.GetHistoricDataBySectionAsync(startDate, endDate);
                    return Ok(result);

                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
                }

            }
        }

        [ApiController]
        [Route("api/[controller]")]
        public class HistoricDatabyCustomerTypeController : ControllerBase
        {
            private readonly HistoricDataService _historicDataService;
            public HistoricDatabyCustomerTypeController(HistoricDataService historicDataService)
            {
                _historicDataService = historicDataService;
            }

            [HttpGet]
            public async Task<IActionResult> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
            {
                try
                {
                    var result = await _historicDataService.GetHistoricDataByCustomerTypeAsync(startDate, endDate);
                    return Ok(result);

                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
                }
                
            }
        }

        [ApiController]
        [Route("api/[controller]")]
        public class TopPowerLossesController : ControllerBase
        {
            private readonly HistoricDataService _historicDataService;
            public TopPowerLossesController(HistoricDataService historicDataService)
            {
                _historicDataService = historicDataService;
            }

            [HttpGet]
            public async Task<IActionResult> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
            {
                try
                {
                    var result = await _historicDataService.GetTopPowerLossesAsync(startDate, endDate);
                    return Ok(result);

                }
                catch (Exception ex)
                {

                    return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
                }

            }
        }


    }
}
