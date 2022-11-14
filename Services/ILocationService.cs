namespace WitnessReportsApi.Services
{
    public interface ILocationService
    {
        public Task<string> GetCountryNameFromIpAddress(string ip);
    }
}