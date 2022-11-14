using Microsoft.AspNetCore.Mvc;
using WitnessReportsApi.Models;
using WitnessReportsApi.Services;

namespace WitnessReportsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WitnessReportController : ControllerBase
    {
        private readonly IReportsService _reportsService;
        private readonly ILocationService _locationService;
        public WitnessReportController(IReportsService reportsService, ILocationService locationService)
        {
            _reportsService = reportsService;
            _locationService = locationService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] WitnessReportDto witnessReportDto)
        {
            if (string.IsNullOrEmpty(witnessReportDto.Name) || string.IsNullOrEmpty(witnessReportDto.Phone))
            {
                return BadRequest("Name and phone are required");
            }
            var report = await _reportsService.Create(witnessReportDto.Name, witnessReportDto.Phone);
            if (report.Country == "Unknown")
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (!string.IsNullOrEmpty(ip))
                {
                    report.Country = await _locationService.GetCountryNameFromIpAddress(ip);
                }
            }
            return Ok(report);
        }
    }
}

