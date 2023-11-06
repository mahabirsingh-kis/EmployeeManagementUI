using EmployeeManagementUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EmployeeManagementUI.Pages.Employee
{
    public class EmployeeModel : PageModel
    {
        public IList<EmployeesResponse> employeesResponseList { get; set; }
   

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44324/api/Employee/GetAll"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    employeesResponseList = JsonConvert.DeserializeObject<List<EmployeesResponse>>(apiResponse);
                }
            }
        }
    }
}
