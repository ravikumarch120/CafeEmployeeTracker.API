using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Cafe> Cafes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Cafes
        var cafeOneId = Guid.NewGuid();
        var cafeTwoId = Guid.NewGuid();

        modelBuilder.Entity<Cafe>().HasData(
            new Cafe { Id = cafeOneId, Name = "Cafe One", Location = "Location One" },
            new Cafe { Id = cafeTwoId, Name = "Cafe Two", Location = "Location Two" }
        );

        // Seed data for Employees
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = Guid.NewGuid(), Name = "John Doe", Gender = "Male", EmailAddress = "john.doe@example.com", PhoneNumber = "1234567890", CafeId = cafeOneId },
            new Employee { Id = Guid.NewGuid(), Name = "Jane Smith", Gender = "Female", EmailAddress = "jane.smith@example.com", PhoneNumber = "0987654321", CafeId = cafeTwoId }
        );
    }
}

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public Guid CafeId { get; set; }
}

public class Cafe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
