namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Models;

    public class TeisterMaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=MeisterDB;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
