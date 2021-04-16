using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;

namespace BlazorServerCRUD.Api.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();

        Department GetDepartment(int departmentId);
    }
    
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public Department GetDepartment(int departmentId)
        {
            var result = _appDbContext.Departments.FirstOrDefault(e => e.DepartmentID == departmentId);
            return result;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.Departments.ToList();
        }
    }
}