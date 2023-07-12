using BlazorAttendance.Shared;
using System;

namespace BlazorAttendance.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        Task GetEmployee();
        List<PunchRecord> Records { get; set; }
        Task GetPunchRecord();
    }
}
