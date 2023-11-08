using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using EmployeeManagementUI.Factory;
using EmployeeManagementUIModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementUI.Pages.Employee
{
    public class AddEmployeeModel : PageModel
    {
        // private readonly AppSettingsModel apiSettings;
        // private readonly IOptions<AppSettingsModel> config;
        private readonly HttpClient _httpClient;

        public AddEmployeeModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public EmployeeDetailsModel employeeDetailsModel { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await GetDepartments();
            return Page();
        }

        private async Task GetDepartments()
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
                var response = await EmployeeManagementApiClientFactory.Instance.CreateEmployee(employeeDetailsModel);
                if (response.message == "Employee created")
                    return Redirect("/Employee/Employee");
                else
                {
                    Error = true;
                    Message = "Error while adding";
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
