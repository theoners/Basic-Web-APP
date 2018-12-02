namespace ToDoList.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using ToDoList.Models;

    public class ToDoDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=ToDoListDB;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
