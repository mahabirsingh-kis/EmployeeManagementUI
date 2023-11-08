using EmployeeManagementUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using EmployeeManagementUI.Factory;
using EmployeeManagementUIModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementUI.Pages.Employee
{
    public class EditEmployeeModel : PageModel
    {
        [BindProperty]
        public EmployeeDetailsModel? employeeDetailsModel { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await GetDepartments();
            employeeDetailsModel = new EmployeeDetailsModel();
            employeeDetailsModel.EmployeeId = id;
            var response = await EmployeeManagementApiClientFactory.Instance.GetEmployeeById(employeeDetailsModel);
            employeeDetailsModel = response.Data;
            if (employeeDetailsModel == null)
            {
                return Redirect("/Employee/Employee");
            }
            return Page();
        }

        async Task GetDepartments()
        {
            var data = await EmployeeManagementApiClientFactory.Instance.GetDepartments();
            Departments = data.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentId.ToString()
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await GetDepartments();
                    return Page();
                }
                var response = await EmployeeManagementApiClientFactory.Instance.UpdateEmployee(employeeDetailsModel);
                if (response.message == "Employee updated")
                    return Redirect("/Employee/Employee");
                else
                {
                    Error = true;
                    Message = "Error while updating";
                    await GetDepartments();
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Error = true;
                await GetDepartments();
                return Page();
            }
        }
    }
}
