using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;

namespace BlazorServerCRUD.Api.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployee(int employeeId);

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        Employee DeleteEmployee(int employeeId);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            var result = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return result.Entity;
        }

        public Employee DeleteEmployee(int employeeId)
        {
            var result = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (result != null)
            {
                _appDbContext.Employees.Remove(result);
                _appDbContext.SaveChanges();
            }

            return result;
        }

        public Employee GetEmployee(int employeeId)
        {
            var result = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _appDbContext.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var result = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);

            if (result != null)
            {
                result.EmployeeName = employee.EmployeeName;
                result.Gender = employee.Gender;
                result.DepartmentID = employee.DepartmentID;
                result.DateOfBirth = employee.DateOfBirth;
                
                _appDbContext.SaveChanges();
            }
            return result;
        }
    }
}