using BlazorRecord.Shared;

namespace BlazorRecord.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        Task GetEmployee();
        List<PunchRecord> Records { get; set; }
        Task GetPunchRecord();

        Task CreatePunchRecord(PunchRecord punchrecord);
    }
}
