using BlazorRecord.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorRecord.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public EmployeeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<PunchRecord> Records { get; set; } = new List<PunchRecord>();

        public async Task GetEmployee()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("/api/employee");
            if (result != null)
            {
                Employees = result;
            }
        }

        public async Task GetPunchRecord()
        {
            var result = await _http.GetFromJsonAsync<List<PunchRecord>>("/api/employee/record");
            if (result != null)
            {
                Records = result;
            }
        }

        public async Task CreatePunchRecord(PunchRecord punchrecord)
        {
            var result = await _http.PostAsJsonAsync("api/employee/record", punchrecord);
            await SetPunchRecord(result);
        }

        private async Task SetPunchRecord(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PunchRecord>>();
            Records = response;
            _navigationManager.NavigateTo("punchrecord");
        }
    }
}
