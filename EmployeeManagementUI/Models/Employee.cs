using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementUI.Models;

public class Employee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string DOB { get; set; }
    public int DepartmentId { get; set; }
}
