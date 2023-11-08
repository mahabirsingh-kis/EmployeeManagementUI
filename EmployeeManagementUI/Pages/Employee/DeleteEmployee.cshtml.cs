using EmployeeManagementUI.Factory;
using EmployeeManagementUIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementUI.Pages.Employee
{
    public class DeleteEmployeeModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public void OnGet(int id)
        {
            Id = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var response = await EmployeeManagementApiClientFactory.Instance.DeleteEmployeeById(Id);
                if (response.message == "Employee deleted")
                    return Redirect("/Employee/Employee");
                else
                {
                    Error = true;
                    Message = "Error while deleting";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Error = true;
                return Page();
            }
        }
    }
}
