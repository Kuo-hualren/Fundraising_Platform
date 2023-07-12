using BlazorDB.Shared;

namespace BlazorDB.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        List<Record> Records { get; set; }
        Task GetRecords();
        Task GetEmployees();
        Task<Employee> GetSingleEmployee(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
