using BlazorAttendance.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace BlazorAttendance.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        //public static List<Employee> emps = new List<Employee> {
        //    new Employee { Id = 1,Name = "Ben", Phone = "0966666666", Email = "qqq@gmail.com",Position = "工程師" },
        //    new Employee { Id = 2,Name = "Alan", Phone = "0988888888", Email = "ddd@gmail.com",Position = "工程師" }
        //};

        

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(emps);
        }

        [HttpGet("record")]
        public async Task<ActionResult<List<PunchRecord>>> GetPunchRecord()
        {
            return Ok(records);
        }
    }
}
