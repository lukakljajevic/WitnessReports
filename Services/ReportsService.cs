using System.Text;
using PhoneNumbers;
using WitnessReportsApi.Models;

namespace WitnessReportsApi.Services
{
    public class ReportsService : IReportsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly PhoneNumberUtil _phoneNumberUtil;
        public ReportsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        }
        public async Task<WitnessReport> Create(string name, string phone)
        {
            var witnessReport = new WitnessReport
            {
                Name = name,
                Phone = phone
            };
            var numberOfCases = await GetNumberOfCases(name);
            witnessReport.Valid = TryParsePhoneNumber(phone, out var phoneNumber) && numberOfCases > 0;
            witnessReport.Country = GetCountryFromPhoneNumber(phoneNumber);
            await WriteToFileAsync(witnessReport);
            return witnessReport;
        }

        private async Task<int> GetNumberOfCases(string name)
        {
            var mostWantedApiUrl = _configuration.GetValue<string>("MostWantedApiUrl");
            var stringBuilder = new StringBuilder(mostWantedApiUrl);
            stringBuilder.Append($"?title={name}");
            var response = await _httpClient.GetAsync(stringBuilder.ToString());
            var wantedResultSet = await response.Content.ReadFromJsonAsync<WantedResultSet>();
            return wantedResultSet == null ? 0 : wantedResultSet.Total.GetValueOrDefault();
        }

        private bool TryParsePhoneNumber(string phone, out PhoneNumber phoneNumber)
        {
            try
            {
                phoneNumber = _phoneNumberUtil.Parse(phone, null);
                return true;
            }
            catch (NumberParseException)
            {
                phoneNumber = null;
                return false;
            }
        }

        private string GetCountryFromPhoneNumber(PhoneNumber phoneNumber)
        {
            if (phoneNumber == null)
            {
                return "Unknown";
            }
            return _phoneNumberUtil.GetRegionCodeForNumber(phoneNumber);
        }

        private async Task WriteToFileAsync(WitnessReport witnessReport)
        {
            using StreamWriter file = new("WitnessReports.txt", append: true);
            await file.WriteLineAsync(witnessReport.ToString());
        }
    }
}

