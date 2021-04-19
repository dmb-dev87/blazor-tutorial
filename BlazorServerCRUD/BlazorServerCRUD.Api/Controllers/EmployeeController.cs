using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorServerCRUD.Api.Models;
using BlazorServerCRUD.Models;

namespace BlazorServerCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult GetEmployee(int id)
        {
            return Ok(_employeeRepository.GetEmployee(id));
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            return Ok(_employeeRepository.AddEmployee(employee));
        }

        [HttpPut]
        public ActionResult UpdateEmployee(Employee employee)
        {
            return Ok(_employeeRepository.UpdateEmployee(employee));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            return Ok(_employeeRepository.DeleteEmployee(id));
        }
    }
}