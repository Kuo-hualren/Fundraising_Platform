namespace BlazorRecord.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ben", Phone = "0966666666", Email = "qqq@gmail.com", Position = "工程師" },
                new Employee { Id = 2, Name = "Alan", Phone = "0988888888", Email = "ddd@gmail.com", Position = "工程師" }
            );

            modelBuilder.Entity<PunchRecord>().HasData(
                new PunchRecord { Id = 1, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 2, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 3, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 4, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 5, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 6, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 7, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 8, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 9, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" },
                new PunchRecord { Id = 10, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" }
            );
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<PunchRecord> Records { get; set; }

    }
}
