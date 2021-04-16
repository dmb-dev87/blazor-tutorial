using System;
using Microsoft.EntityFrameworkCore;
using BlazorServerCRUD.Models;

namespace BlazorServerCRUD.Api.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Department
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 1, DepartmentName = "Admin" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 3, DepartmentName = "Payroll" });

            //Employee
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 1, EmployeeName = "John", DateOfBirth = new DateTime(1992, 07, 01), Gender = Gender.Male, DepartmentID = 1 });
        }
    }
}