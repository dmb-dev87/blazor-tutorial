using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
            if (result != null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }            
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            List<Employee> employees = await _appDbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employee.EmployeeID);

            if (result != null)
            {
                result.EmployeeName = employee.EmployeeName;
                result.DateOfBirth = employee.DateOfBirth;
                result.DepartmentID = employee.DepartmentID;
                result.Gender = employee.Gender;

                await _appDbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}