using BlazorDB.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorDB.Client.Services.EmployeeService
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
        
        public List<Record> Records { get; set; } = new List<Record>();

        
        public async Task<Employee> GetSingleEmployee(int id)
        {
            var result = await _http.GetFromJsonAsync<Employee>($"api/employ/{id}");
            if (result != null)
                return result;
            throw new Exception("Employee not found!");

        }

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("api/employ");
            if (result != null)
            {
                Employees = result;
            }

        }

        public async Task GetRecords()
        {
            var result = await _http.GetFromJsonAsync<List<Record>>("/api/employ/records");
            if (result != null)
                Records = result;
        }

        public async Task CreateEmployee(Employee employee)
        {
            var result = await _http.PostAsJsonAsync("api/employ", employee);
            await SetEmployees(result);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var result = await _http.PutAsJsonAsync($"api/employ/{employee.Id}", employee);
            await SetEmployees(result);
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _http.DeleteAsync($"api/employ/{id}");
            await SetEmployees(result);
        }


    private async Task SetEmployees(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Employee>>();
            Employees = response;
            _navigationManager.NavigateTo("employees");
        }
    }
}
