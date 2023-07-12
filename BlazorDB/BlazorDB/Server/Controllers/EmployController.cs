using BlazorDB.Shared;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace BlazorDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        //public static List<Record> records = new List<Record> {
        //    new Record { Id = 1, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0"},
        //    new Record { Id = 2, Name = "Alan", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0"}
        //};

        //public static List<Employee> employees = new List<Employee> {
        //    new Employee { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", Record = records[0], RecordId = 1},
        //    new Employee { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", Record = records[1], RecordId = 2}
        //};

        private readonly DataContext _context;
        public EmployController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var emps = await _context.Employees.Include(sh => sh.Record).ToListAsync();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            
            var emp = await _context.Employees
                .Include(h => h.Record)
                .FirstOrDefaultAsync(h => h.Id == id);
            if ( emp== null)
            {
                return NotFound("找不到");
            }
            return Ok(emp);
        }


        [HttpGet("records")]
        public async Task<ActionResult<List<Record>>> GetRecords()
        {
            var records = await _context.Records.ToListAsync();
            return Ok(records);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            employee.Record = null;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee, int id)
        {
            var dbEmploy = await _context.Employees
                .Include(sh => sh.Record)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbEmploy == null)
                return NotFound("Sorry");

            dbEmploy.Name = employee.Name;
            dbEmploy.Phone = employee.Phone;
            dbEmploy.Email = employee.Email;
            dbEmploy.Position = employee.Position;
            dbEmploy.RecordId = employee.Id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmploy = await _context.Employees
                .Include(sh => sh.Record)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbEmploy == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Employees.Remove(dbEmploy);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }


        private async Task<List<Employee>> GetDbEmployees()
        {
            return await _context.Employees.Include(sh => sh.Record).ToListAsync();
        }
    }
}
