using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;

namespace BlazorServerCRUD.Api.Models
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartment(int departmentId);
        Task<IEnumerable<Department>> GetDepartments();
    }
}