using IpData;

namespace WitnessReportsApi.Services
{
    public class LocationService : ILocationService
    {
        private readonly IConfiguration _configuration;
        private readonly IpDataClient _ipDataClient;
        public LocationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _ipDataClient = new IpDataClient(_configuration.GetValue<string>("IpDataApiKey"));
        }
        public async Task<string> GetCountryNameFromIpAddress(string ip)
        {
            try
            {
                var ipInfo = await _ipDataClient.Lookup(ip);
                return ipInfo.CountryName;
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }
    }
}