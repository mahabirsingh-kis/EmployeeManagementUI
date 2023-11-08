using EmployeeManagementUIModels;

namespace EmployeeManagementUIApiClient
{
    public partial class ApiClient
    {
        public async Task<Message<EmployeeDetailsModel>> CreateEmployee(EmployeeDetailsModel employeeDetailsModel)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Employee/CreateEmployee"));
            var result = await PostAsync<EmployeeDetailsModel>(requestUrl, employeeDetailsModel);
            return result;
        }

        public async Task<Message<EmployeeDetailsModel>> UpdateEmployee(EmployeeDetailsModel employeeDetailsModel)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Employee/UpdateEmployee"));
            var result = await PostAsync<EmployeeDetailsModel>(requestUrl, employeeDetailsModel);
            return result;
        }

        public async Task<Message<EmployeeDetailsModel>> GetEmployeeById(EmployeeDetailsModel employeeDetailsModel)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
            "Employee/GetEmployeeById"));
            var result = await GetAsyncData<EmployeeDetailsModel>(requestUrl, employeeDetailsModel.EmployeeId);
            return new Message<EmployeeDetailsModel>
            {
                Data = result
            };
        }

        public async Task<Message<bool>> DeleteEmployeeById(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
            "Employee/DeleteEmployee"));
            var result = await DeleteAsyncResponse<bool>(requestUrl, id);
            return result;
        }

        public async Task<List<DepartmentUIModels>> GetDepartments()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
            "Employee/GetDepartments"));
            var result = await GetAsyncList<DepartmentUIModels>(requestUrl);
            return result;
        }

        public async Task<List<EmployeesResponseModel>> GetAllEmployee()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
            "Employee/GetAll"));
            var result = await GetAsyncList<EmployeesResponseModel>(requestUrl);
            return result;
        }
    }
}