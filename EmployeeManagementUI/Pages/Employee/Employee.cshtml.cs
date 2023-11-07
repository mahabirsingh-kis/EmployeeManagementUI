using EmployeeManagementUI.Factory;
using EmployeeManagementUI.Models;
using EmployeeManagementUIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EmployeeManagementUI.Pages.Employee
{
    public class EmployeeModel : PageModel
    {
        public IList<EmployeesResponseModel> employeesResponseList { get; set; }
        [BindProperty]
        public string SearchText { get; set; }
   
        public async Task OnGetAsync()
        {
            await GetEmployees();
        }

        private async Task GetEmployees()
        {
            var response = await EmployeeManagementApiClientFactory.Instance.GetAllEmployee();
            employeesResponseList = response.ToList();
            if (!string.IsNullOrEmpty(SearchText))
            {
                employeesResponseList = employeesResponseList.Where(x =>
                    x.Name?.ToLower().Contains(SearchText.ToLower()) == true ||
                    x.Email?.ToLower().Contains(SearchText.ToLower()) == true
                ).ToList();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await GetEmployees();
            return Page();
        }
    }
}
