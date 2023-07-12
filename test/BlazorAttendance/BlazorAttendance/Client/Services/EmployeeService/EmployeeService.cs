using BlazorAttendance.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http.Json;

namespace BlazorAttendance.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        public EmployeeService(HttpClient http)
        {
            _http = http;
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
    }
}
