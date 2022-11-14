using WitnessReportsApi.Models;

namespace WitnessReportsApi.Services
{
    public interface IReportsService
    {
        public Task<WitnessReport> Create(string name, string phone);
    }
}

