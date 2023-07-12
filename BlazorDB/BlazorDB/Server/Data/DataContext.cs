
namespace BlazorDB.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasData(
                new Record { Id = 1, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0" },
                new Record { Id = 2, Name = "Alan", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0" }
            );
            

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", RecordId = 1 },
                new Employee { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", RecordId = 2 }
            );

            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Record> Records { get; set; }

    }
}
