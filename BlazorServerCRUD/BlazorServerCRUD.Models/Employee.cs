namespace BlazorServerCRUD.Models
{
    public class Employee
    {
        public int EmployeeID{get; set;}
        public string EmployeeName{get; set;}
        [DataType(DataType.Date)]
        public DateTime DateOfBirth{get; set;}
        public Gender Gender{get; set;}
        public Department Department{get; set;}
    }
}