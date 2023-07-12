using BlazorRecord.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRecord.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        //public static List<Employee> emps = new List<Employee> {
        //    new Employee { Id = 1,Name = "Ben", Phone = "0966666666", Email = "qqq@gmail.com",Position = "工程師" },
        //    new Employee { Id = 2,Name = "Alan", Phone = "0988888888", Email = "ddd@gmail.com",Position = "工程師" }
        //};

        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        { 
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var emps = await _context.Employees.ToListAsync();
            return Ok(emps);
        }

        [HttpGet("record")]
        public async Task<ActionResult<List<PunchRecord>>> GetPunchRecord()
        {
            var rec = await _context.Records.ToListAsync();
            return Ok(rec);
        }

        [HttpPost]
        public async Task<ActionResult<List<PunchRecord>>> CreatePunchRecord(PunchRecord punchrecord)
        {
            punchrecord.Hours = null;
            _context.Records.Add(punchrecord);
            await _context.SaveChangesAsync();

            return Ok(await GetDbRecord());
        }


        private async Task<List<PunchRecord>> GetDbRecord()
        {
            return await _context.Records.ToListAsync();
        }
    }
}
