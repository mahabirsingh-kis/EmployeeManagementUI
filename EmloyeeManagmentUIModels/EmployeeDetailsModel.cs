using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementUIModels;

public class EmployeeDetailsModel
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Date)]
   public DateTime DOB { get; set; }
    public int DepartmentId { get; set; }
}
