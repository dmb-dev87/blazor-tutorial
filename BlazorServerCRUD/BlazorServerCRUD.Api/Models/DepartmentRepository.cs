using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            var result = await _appDbContext.Departments.FirstOrDefaultAsync(e => e.DepartmentID == departmentId);
            return result;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            List<Department> departments = await _appDbContext.Departments.ToListAsync();
            return departments;
        }
    }
}